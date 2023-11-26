using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearServerAuth.Migrations.Auth
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "document_type",
                columns: table => new
                {
                    document_type_id = table.Column<long>(type: "bigint", nullable: false),
                    document_type_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_type", x => x.document_type_id);
                });

            migrationBuilder.CreateTable(
                name: "payment_type",
                columns: table => new
                {
                    payment_type_id = table.Column<long>(type: "bigint", nullable: false),
                    payment_type_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_type", x => x.payment_type_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    role_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    role_value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account", x => x.account_id);
                    table.ForeignKey(
                        name: "fk_account_account_r_role",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "document",
                columns: table => new
                {
                    document_id = table.Column<long>(type: "bigint", nullable: false),
                    document_type_id = table.Column<long>(type: "bigint", nullable: false),
                    account_id = table.Column<long>(type: "bigint", nullable: false),
                    document_summ = table.Column<double>(type: "double precision", nullable: false),
                    document_simm_discount = table.Column<double>(type: "double precision", nullable: false),
                    document_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document", x => x.document_id);
                    table.ForeignKey(
                        name: "fk_document_account_t_account",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_document__document",
                        column: x => x.document_type_id,
                        principalTable: "document_type",
                        principalColumn: "document_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    account_id = table.Column<long>(type: "bigint", nullable: true),
                    user_password_hash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    user_login = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    user_email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    user_phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    user_author = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    user_working = table.Column<bool>(type: "boolean", nullable: false),
                    user_avatar = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.user_id);
                    table.ForeignKey(
                        name: "fk_user_user_to_a_account",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment_document",
                columns: table => new
                {
                    payment_document_id = table.Column<long>(type: "bigint", nullable: false),
                    document_id = table.Column<long>(type: "bigint", nullable: false),
                    payment_type_id = table.Column<long>(type: "bigint", nullable: false),
                    payment_document_summ = table.Column<double>(type: "double precision", nullable: false),
                    payment_document_status = table.Column<bool>(type: "boolean", nullable: false),
                    payment_document_check = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    payment_document_summ_result = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_document", x => x.payment_document_id);
                    table.ForeignKey(
                        name: "fk_payment__document__document",
                        column: x => x.document_id,
                        principalTable: "document",
                        principalColumn: "document_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_payment__payment_t_payment_",
                        column: x => x.payment_type_id,
                        principalTable: "payment_type",
                        principalColumn: "payment_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "account_pk",
                table: "account",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "account_role_fk",
                table: "account",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "user_to_account2_fk",
                table: "account",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "account_to_document_fk",
                table: "document",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "document_pk",
                table: "document",
                column: "document_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "document_type_to_document_fk",
                table: "document",
                column: "document_type_id");

            migrationBuilder.CreateIndex(
                name: "document_type_pk",
                table: "document_type",
                column: "document_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "document_to_paydocument_fk",
                table: "payment_document",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "payment_document_pk",
                table: "payment_document",
                column: "payment_document_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "payment_type_to_paydocument_fk",
                table: "payment_document",
                column: "payment_type_id");

            migrationBuilder.CreateIndex(
                name: "payment_type_pk",
                table: "payment_type",
                column: "payment_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "role_pk",
                table: "role",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_pk",
                table: "user",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_to_account_fk",
                table: "user",
                column: "account_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_user_to_a_user",
                table: "account",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_account_r_role",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "fk_account_user_to_a_user",
                table: "account");

            migrationBuilder.DropTable(
                name: "payment_document");

            migrationBuilder.DropTable(
                name: "document");

            migrationBuilder.DropTable(
                name: "payment_type");

            migrationBuilder.DropTable(
                name: "document_type");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}

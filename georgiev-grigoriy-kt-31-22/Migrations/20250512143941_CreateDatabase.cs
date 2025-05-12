using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace georgiev_grigoriy_kt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Degree_id = table.Column<int>(type: "int", nullable: false, comment: "Id Степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Название степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_degree_degree_id", x => x.Degree_id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Disciplines_id = table.Column<int>(type: "int", nullable: false, comment: "Id дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disciplines_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_disciplines_id", x => x.Disciplines_id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id_position = table.Column<int>(type: "int", nullable: false, comment: "Айдишник должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Positions_posinion_id", x => x.id_position);
                });

            migrationBuilder.CreateTable(
                name: "Prepods",
                columns: table => new
                {
                    id_prepod = table.Column<int>(type: "int", nullable: false, comment: "Айдишник преподавателей")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prepod_firstname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Имя преподавателя"),
                    prepod_lastname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Отчество преподавателя"),
                    prepod_midname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Фамилия преподавателя"),
                    prepod_degreeId = table.Column<int>(type: "int", nullable: false, comment: "Степень преподавателя"),
                    prepod_positionId = table.Column<int>(type: "int", nullable: false, comment: "Должность преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Prepods_prepods_id", x => x.id_prepod);
                    table.ForeignKey(
                        name: "fk_degree_id",
                        column: x => x.prepod_degreeId,
                        principalTable: "Degrees",
                        principalColumn: "Degree_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_position_id",
                        column: x => x.prepod_positionId,
                        principalTable: "Positions",
                        principalColumn: "id_position",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_cafedra",
                columns: table => new
                {
                    cafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Id Кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cafedra_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Название кафедры"),
                    c_admin_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор администратора(заведующего) кафедры"),
                    total = table.Column<int>(type: "int", nullable: false, comment: "Количество преподавателей"),
                    date_Osnovania = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата основания")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_cafedra_cafedra_id", x => x.cafedra_id);
                    table.ForeignKey(
                        name: "fk_admin_id_prepod_id",
                        column: x => x.c_admin_id,
                        principalTable: "Prepods",
                        principalColumn: "id_prepod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_Nagruzka",
                columns: table => new
                {
                    para_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор занятия")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор предмета"),
                    c_prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    c_nagruzka_hours = table.Column<int>(type: "int", nullable: false, comment: "Нагрузка в часах")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Nagruzka_Id", x => x.para_id);
                    table.ForeignKey(
                        name: "fk_discipline_id",
                        column: x => x.c_discipline_id,
                        principalTable: "Disciplines",
                        principalColumn: "Disciplines_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_prepod_id",
                        column: x => x.c_prepod_id,
                        principalTable: "Prepods",
                        principalColumn: "id_prepod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_cafedra_fk_admin_id_prepod_id",
                table: "cd_cafedra",
                column: "cafedra_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_cafedra_c_admin_id",
                table: "cd_cafedra",
                column: "c_admin_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_Nagruzka_fk_prepod_id",
                table: "cd_Nagruzka",
                column: "c_prepod_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_Nagruzka_fk_subject_id",
                table: "cd_Nagruzka",
                column: "c_discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_Prepods_fk_degree_id",
                table: "Prepods",
                column: "prepod_degreeId");

            migrationBuilder.CreateIndex(
                name: "idx_Prepods_fk_position_id",
                table: "Prepods",
                column: "prepod_positionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_cafedra");

            migrationBuilder.DropTable(
                name: "cd_Nagruzka");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Prepods");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}

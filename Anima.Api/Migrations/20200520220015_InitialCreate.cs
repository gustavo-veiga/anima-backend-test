using Microsoft.EntityFrameworkCore.Migrations;

namespace Anima.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Ra = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(fixedLength: true, maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 180, nullable: false),
                    Email = table.Column<string>(maxLength: 180, nullable: false),
                    Login = table.Column<string>(maxLength: 40, nullable: false),
                    Senha = table.Column<string>(maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Ra);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    CodFuncionario = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(fixedLength: true, maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 180, nullable: false),
                    Email = table.Column<string>(maxLength: 180, nullable: false),
                    Login = table.Column<string>(maxLength: 40, nullable: false),
                    Senha = table.Column<string>(maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.CodFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    CodGrade = table.Column<int>(nullable: false),
                    Curso = table.Column<string>(maxLength: 180, nullable: false),
                    Turma = table.Column<string>(maxLength: 180, nullable: false),
                    Disciplina = table.Column<string>(maxLength: 180, nullable: false),
                    DocenteCodFuncionario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.CodGrade);
                    table.ForeignKey(
                        name: "FK_Grades_Professores_DocenteCodFuncionario",
                        column: x => x.DocenteCodFuncionario,
                        principalTable: "Professores",
                        principalColumn: "CodFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    CodGrade = table.Column<int>(nullable: false),
                    Ra = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => new { x.CodGrade, x.Ra });
                    table.ForeignKey(
                        name: "FK_Matriculas_Grades_CodGrade",
                        column: x => x.CodGrade,
                        principalTable: "Grades",
                        principalColumn: "CodGrade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_Ra",
                        column: x => x.Ra,
                        principalTable: "Alunos",
                        principalColumn: "Ra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Cpf",
                table: "Alunos",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Email",
                table: "Alunos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Login",
                table: "Alunos",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_DocenteCodFuncionario",
                table: "Grades",
                column: "DocenteCodFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_Ra",
                table: "Matriculas",
                column: "Ra");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Cpf",
                table: "Professores",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Email",
                table: "Professores",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Login",
                table: "Professores",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}

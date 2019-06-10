using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class ClassPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClassPlan",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClass = table.Column<int>(nullable: false),
                    IdClassPlan = table.Column<int>(nullable: true),
                    ScoreFinalDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassPlans_Classes_IdClassPlan",
                        column: x => x.IdClassPlan,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassPlanBookItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClassPlan = table.Column<int>(nullable: false),
                    IdBook = table.Column<int>(nullable: false),
                    BibliographyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPlanBookItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassPlanBookItems_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassPlanBookItems_ClassPlans_IdClassPlan",
                        column: x => x.IdClassPlan,
                        principalTable: "ClassPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassPlanResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClassPlan = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPlanResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassPlanResources_ClassPlans_IdClassPlan",
                        column: x => x.IdClassPlan,
                        principalTable: "ClassPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassPlanScoreCompositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClassPlan = table.Column<int>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ScoreWeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPlanScoreCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassPlanScoreCompositions_ClassPlans_IdClassPlan",
                        column: x => x.IdClassPlan,
                        principalTable: "ClassPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassPlanWeekItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClassPlan = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClassType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Books = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPlanWeekItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassPlanWeekItems_ClassPlans_IdClassPlan",
                        column: x => x.IdClassPlan,
                        principalTable: "ClassPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassPlanBookItems_IdBook",
                table: "ClassPlanBookItems",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPlanBookItems_IdClassPlan",
                table: "ClassPlanBookItems",
                column: "IdClassPlan");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPlanResources_IdClassPlan",
                table: "ClassPlanResources",
                column: "IdClassPlan");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPlans_IdClassPlan",
                table: "ClassPlans",
                column: "IdClassPlan",
                unique: true,
                filter: "[IdClassPlan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPlanScoreCompositions_IdClassPlan",
                table: "ClassPlanScoreCompositions",
                column: "IdClassPlan");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPlanWeekItems_IdClassPlan",
                table: "ClassPlanWeekItems",
                column: "IdClassPlan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassPlanBookItems");

            migrationBuilder.DropTable(
                name: "ClassPlanResources");

            migrationBuilder.DropTable(
                name: "ClassPlanScoreCompositions");

            migrationBuilder.DropTable(
                name: "ClassPlanWeekItems");

            migrationBuilder.DropTable(
                name: "ClassPlans");

            migrationBuilder.DropColumn(
                name: "IdClassPlan",
                table: "Classes");
        }
    }
}

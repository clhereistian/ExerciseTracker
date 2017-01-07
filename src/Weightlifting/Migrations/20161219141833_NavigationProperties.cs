using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weightlifting.Migrations
{
    public partial class NavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sets",
                table: "Sets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workouts",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workout",
                table: "Workouts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Set",
                table: "Sets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Set_ExerciseId",
                table: "Sets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Set_WorkoutId",
                table: "Sets",
                column: "WorkoutId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                maxLength: 50,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercises",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Set_Exercise_ExerciseId",
                table: "Sets",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Set_Workout_WorkoutId",
                table: "Sets",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Workouts",
                newName: "Workout");

            migrationBuilder.RenameTable(
                name: "Sets",
                newName: "Set");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Set_Exercise_ExerciseId",
                table: "Set");

            migrationBuilder.DropForeignKey(
                name: "FK_Set_Workout_WorkoutId",
                table: "Set");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workout",
                table: "Workout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Set",
                table: "Set");

            migrationBuilder.DropIndex(
                name: "IX_Set_ExerciseId",
                table: "Set");

            migrationBuilder.DropIndex(
                name: "IX_Set_WorkoutId",
                table: "Set");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workout",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workouts",
                table: "Workout",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sets",
                table: "Set",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercise",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercise",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercise",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Workout",
                newName: "Workouts");

            migrationBuilder.RenameTable(
                name: "Set",
                newName: "Sets");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");
        }
    }
}

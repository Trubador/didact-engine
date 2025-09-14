using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddExecutionModesDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flow_ExecutionMode_ExecutionModeId",
                table: "Flow");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowRun_ExecutionMode_ExecutionModeId",
                table: "FlowRun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExecutionMode",
                table: "ExecutionMode");

            migrationBuilder.RenameTable(
                name: "ExecutionMode",
                newName: "ExecutionModes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExecutionModes",
                table: "ExecutionModes",
                column: "ExecutionModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flow_ExecutionModes_ExecutionModeId",
                table: "Flow",
                column: "ExecutionModeId",
                principalTable: "ExecutionModes",
                principalColumn: "ExecutionModeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowRun_ExecutionModes_ExecutionModeId",
                table: "FlowRun",
                column: "ExecutionModeId",
                principalTable: "ExecutionModes",
                principalColumn: "ExecutionModeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flow_ExecutionModes_ExecutionModeId",
                table: "Flow");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowRun_ExecutionModes_ExecutionModeId",
                table: "FlowRun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExecutionModes",
                table: "ExecutionModes");

            migrationBuilder.RenameTable(
                name: "ExecutionModes",
                newName: "ExecutionMode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExecutionMode",
                table: "ExecutionMode",
                column: "ExecutionModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flow_ExecutionMode_ExecutionModeId",
                table: "Flow",
                column: "ExecutionModeId",
                principalTable: "ExecutionMode",
                principalColumn: "ExecutionModeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowRun_ExecutionMode_ExecutionModeId",
                table: "FlowRun",
                column: "ExecutionModeId",
                principalTable: "ExecutionMode",
                principalColumn: "ExecutionModeId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadStation.Migrations
{
    /// <inheritdoc />
    public partial class newversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_SubscriptionContent_DownloadCount",
                table: "SubscriptionContent");

            migrationBuilder.DropColumn(
                name: "DownloadCount",
                table: "SubscriptionContent");

            migrationBuilder.DropColumn(
                name: "SelectedContent",
                table: "SubscriptionContent");

            migrationBuilder.RenameColumn(
                name: "PublicationDate",
                table: "Content",
                newName: "PublishingDate");

            migrationBuilder.AddColumn<int>(
                name: "DownloadCounter",
                table: "UserSubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MembershipCounter",
                table: "UserSubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 3, 47, 28, 757, DateTimeKind.Local).AddTicks(8492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<float>(
                name: "PricePerMonth",
                table: "Subscription",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 4.99f);

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableContentPerMonth",
                table: "Subscription",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentCounter = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContent_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CH_SubscriptionContent_DownloadCounter",
                table: "UserSubscription",
                sql: "DownloadCounter>=0");

            migrationBuilder.AddCheckConstraint(
                name: "CH_Subscription_DownloadableContentPerMonth",
                table: "Subscription",
                sql: "DownloadableContentPerMonth>=15");

            migrationBuilder.CreateIndex(
                name: "IX_UserContent_ContentId",
                table: "UserContent",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContent_UserId",
                table: "UserContent",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContent");

            migrationBuilder.DropCheckConstraint(
                name: "CH_SubscriptionContent_DownloadCounter",
                table: "UserSubscription");

            migrationBuilder.DropCheckConstraint(
                name: "CH_Subscription_DownloadableContentPerMonth",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "DownloadCounter",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "MembershipCounter",
                table: "UserSubscription");

            migrationBuilder.RenameColumn(
                name: "PublishingDate",
                table: "Content",
                newName: "PublicationDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 2, 3, 47, 28, 757, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.AddColumn<int>(
                name: "DownloadCount",
                table: "SubscriptionContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SelectedContent",
                table: "SubscriptionContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<float>(
                name: "PricePerMonth",
                table: "Subscription",
                type: "real",
                nullable: false,
                defaultValue: 4.99f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableContentPerMonth",
                table: "Subscription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "CH_SubscriptionContent_DownloadCount",
                table: "SubscriptionContent",
                sql: "DownloadCount>=0");
        }
    }
}

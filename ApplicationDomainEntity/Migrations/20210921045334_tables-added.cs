using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomainEntity.Migrations
{
    public partial class tablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypesDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddressDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddressDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddressDb_AddressDb_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingAddressDb_ContactDb_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: true),
                    DesignedFor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDb_MaterialTypesDb_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypesDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    AccountPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDb_ShippingAddressDb_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "ShippingAddressDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikedItemsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedItemsDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedItemsDb_AccountDb_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikedItemsDb_ItemDb_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDb_ShippingAddressId",
                table: "AccountDb",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDb_MaterialTypeId",
                table: "ItemDb",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedItemsDb_AccountId",
                table: "LikedItemsDb",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedItemsDb_ItemId",
                table: "LikedItemsDb",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddressDb_AddressId",
                table: "ShippingAddressDb",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddressDb_ContactId",
                table: "ShippingAddressDb",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedItemsDb");

            migrationBuilder.DropTable(
                name: "AccountDb");

            migrationBuilder.DropTable(
                name: "ItemDb");

            migrationBuilder.DropTable(
                name: "ShippingAddressDb");

            migrationBuilder.DropTable(
                name: "MaterialTypesDb");

            migrationBuilder.DropTable(
                name: "AddressDb");

            migrationBuilder.DropTable(
                name: "ContactDb");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BibleViewer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BibleSubject",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleSubject", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "BibleType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleType", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "Code", "Index", "Name", "ShortName" },
                values: new object[,]
                {
                    { "1ch", 12, "역대상", "대상" },
                    { "1co", 45, "고린도전서", "고전" },
                    { "1jn", 61, "요한1서", "요일" },
                    { "1ki", 10, "열왕기상", "왕상" },
                    { "1pe", 59, "베드로전서", "벧전" },
                    { "1sa", 8, "사무엘상", "삼상" },
                    { "1th", 51, "데살로니가전서", "살전" },
                    { "1ti", 53, "디모데전서", "딤전" },
                    { "2ch", 13, "역대하", "대하" },
                    { "2co", 46, "고린도후서", "고후" },
                    { "2jn", 62, "요한2서", "요이" },
                    { "2ki", 11, "열왕기하", "왕하" },
                    { "2pe", 60, "베드로후서", "벧후" },
                    { "2sa", 9, "사무엘하", "삼하" },
                    { "2th", 52, "데살로니가후서", "살후" },
                    { "2ti", 54, "디모데후서", "딤후" },
                    { "3jn", 63, "요한3서", "요삼" },
                    { "act", 43, "사도행전", "행" },
                    { "amo", 29, "아모스", "암" },
                    { "col", 50, "골로새서", "골" },
                    { "dan", 26, "다니엘", "단" },
                    { "deu", 4, "신명기", "신" },
                    { "ecc", 20, "전도서", "전" },
                    { "eph", 48, "에베소서", "엡" },
                    { "est", 16, "에스더", "에" },
                    { "exo", 1, "출애굽기", "출" },
                    { "ezk", 25, "에스겔", "겔" },
                    { "ezr", 14, "에스라", "스" },
                    { "gal", 47, "갈라디아서", "갈" },
                    { "gen", 0, "창세기", "창" },
                    { "hab", 34, "하박국", "합" },
                    { "hag", 36, "학개", "학" },
                    { "heb", 57, "히브리서", "히" },
                    { "hos", 27, "호세아", "호" },
                    { "isa", 22, "이사야", "사" },
                    { "jas", 58, "야고보서", "약" },
                    { "jdg", 6, "사사기", "삿" },
                    { "jer", 23, "예레미야", "렘" },
                    { "jhn", 42, "요한복음", "요" },
                    { "jnh", 31, "요나", "욘" },
                    { "job", 17, "욥기", "욥" },
                    { "jol", 28, "요엘", "욜" },
                    { "jos", 5, "여호수아", "수" },
                    { "jud", 64, "유다서", "유" },
                    { "lam", 24, "예레미야애가", "애" },
                    { "lev", 2, "레위기", "레" },
                    { "luk", 41, "누가복음", "눅" },
                    { "mal", 38, "말라기", "말" },
                    { "mat", 39, "마태복음", "마" },
                    { "mic", 32, "미가", "미" },
                    { "mrk", 40, "마가복음", "막" },
                    { "nam", 33, "나훔", "나" },
                    { "neh", 15, "느헤미야", "느" },
                    { "num", 3, "민수기", "민" },
                    { "oba", 30, "오바댜", "옵" },
                    { "phm", 56, "빌레몬서", "몬" },
                    { "php", 49, "빌리보서", "빌" },
                    { "pro", 19, "잠언", "잠" },
                    { "psa", 18, "시편", "시" },
                    { "rev", 65, "요한계시록", "계" },
                    { "rom", 44, "로마서", "롬" },
                    { "rut", 7, "룻기", "룻" },
                    { "sng", 21, "아가", "아" },
                    { "tit", 55, "디도서", "딛" },
                    { "zec", 37, "스가랴", "슥" },
                    { "zep", 35, "스바냐", "습" }
                });

            migrationBuilder.InsertData(
                table: "BibleType",
                columns: new[] { "Code", "Index", "Name" },
                values: new object[,]
                {
                    { "COG", 4, "공동번역" },
                    { "COGNEW", 5, "공동번역 개정판" },
                    { "GAE", 0, "개역개정" },
                    { "HAN", 1, "개역한글" },
                    { "SAE", 2, "표준새번역" },
                    { "SAENEW", 3, "새번역" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BibleSubject_Index",
                table: "BibleSubject",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_BibleType_Index",
                table: "BibleType",
                column: "Index");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibleSubject");

            migrationBuilder.DropTable(
                name: "BibleType");
        }
    }
}

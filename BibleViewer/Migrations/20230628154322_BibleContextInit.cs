using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibleViewer.Migrations
{
    public partial class BibleContextInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BibleSubject",
                columns: table => new
                {
                    BibleSubjectKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BibleSubjectName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    BibleSubjectDescription = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleSubject", x => x.BibleSubjectKey);
                });

            migrationBuilder.CreateTable(
                name: "BibleType",
                columns: table => new
                {
                    BibleTypeKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BibleTypeName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleType", x => x.BibleTypeKey);
                });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 1, "창세기", "창" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 2, "출애굽기", "출" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 3, "레위기", "레" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 4, "민수기", "민" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 5, "신명기", "신" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 6, "여호수아", "수" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 7, "사사기", "삿" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 8, "룻기", "룻" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 9, "사무엘상", "삼상" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 10, "사무엘하", "삼하" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 11, "열왕기상", "왕상" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 12, "열왕기하", "왕하" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 13, "역대상", "대상" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 14, "역대하", "대하" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 15, "에스라", "스" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 16, "느헤미야", "느" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 17, "에스더", "에" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 18, "욥기", "욥" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 19, "시편", "시" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 20, "잠언", "잠" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 21, "전도서", "전" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 22, "아가", "아" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 23, "이사야", "사" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 24, "예레미야", "렘" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 25, "예레미아애가", "애" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 26, "에스겔", "겔" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 27, "다니엘", "단" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 28, "호세아", "호" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 29, "요엘", "욜" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 30, "아모스", "암" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 31, "오바댜", "옵" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 32, "요나", "욘" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 33, "미가", "미" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 34, "나훔", "나" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 35, "하박국", "합" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 36, "스바냐", "습" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 37, "학개", "학" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 38, "스가랴", "슥" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 39, "말라기", "말" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 40, "마태복음", "마" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 41, "마가복음", "막" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 42, "누가복음", "눅" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 43, "요한복음", "요" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 44, "사도행전", "행" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 45, "로마서", "롬" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 46, "고린도전서", "고전" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 47, "고린도후서", "고후" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 48, "갈라디아서", "갈" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 49, "에베소서", "엡" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 50, "빌립보서", "빌" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 51, "골로새서", "골" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 52, "데살로니가전서", "살전" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 53, "데살로니가후서", "살후" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 54, "디모데전서", "딤전" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 55, "디모데후서", "딤후" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 56, "디도서", "딛" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 57, "빌레몬서", "몬" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 58, "히브리서", "히" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 59, "야고보서", "약" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 60, "베드로전서", "벧전" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 61, "베드로후서", "벧후" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 62, "요한1서", "요일" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 63, "요한2서", "요이" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 64, "요한3서", "요삼" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 65, "유다서", "유" });

            migrationBuilder.InsertData(
                table: "BibleSubject",
                columns: new[] { "BibleSubjectKey", "BibleSubjectDescription", "BibleSubjectName" },
                values: new object[] { 66, "요한계시록", "계" });

            migrationBuilder.InsertData(
                table: "BibleType",
                columns: new[] { "BibleTypeKey", "BibleTypeName" },
                values: new object[] { 1, "개역개정" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibleSubject");

            migrationBuilder.DropTable(
                name: "BibleType");
        }
    }
}

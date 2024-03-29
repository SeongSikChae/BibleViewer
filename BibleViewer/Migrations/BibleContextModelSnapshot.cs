﻿// <auto-generated />
using BibleViewer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibleViewer.Migrations
{
    [DbContext(typeof(BibleContext))]
    partial class BibleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.19");

            modelBuilder.Entity("BibleViewer.Context.BibleSubject", b =>
                {
                    b.Property<int>("BibleSubjectKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BibleSubjectDescription")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("BibleSubjectName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("BibleSubjectKey");

                    b.ToTable("BibleSubject");

                    b.HasData(
                        new
                        {
                            BibleSubjectKey = 1,
                            BibleSubjectDescription = "창세기",
                            BibleSubjectName = "창"
                        },
                        new
                        {
                            BibleSubjectKey = 2,
                            BibleSubjectDescription = "출애굽기",
                            BibleSubjectName = "출"
                        },
                        new
                        {
                            BibleSubjectKey = 3,
                            BibleSubjectDescription = "레위기",
                            BibleSubjectName = "레"
                        },
                        new
                        {
                            BibleSubjectKey = 4,
                            BibleSubjectDescription = "민수기",
                            BibleSubjectName = "민"
                        },
                        new
                        {
                            BibleSubjectKey = 5,
                            BibleSubjectDescription = "신명기",
                            BibleSubjectName = "신"
                        },
                        new
                        {
                            BibleSubjectKey = 6,
                            BibleSubjectDescription = "여호수아",
                            BibleSubjectName = "수"
                        },
                        new
                        {
                            BibleSubjectKey = 7,
                            BibleSubjectDescription = "사사기",
                            BibleSubjectName = "삿"
                        },
                        new
                        {
                            BibleSubjectKey = 8,
                            BibleSubjectDescription = "룻기",
                            BibleSubjectName = "룻"
                        },
                        new
                        {
                            BibleSubjectKey = 9,
                            BibleSubjectDescription = "사무엘상",
                            BibleSubjectName = "삼상"
                        },
                        new
                        {
                            BibleSubjectKey = 10,
                            BibleSubjectDescription = "사무엘하",
                            BibleSubjectName = "삼하"
                        },
                        new
                        {
                            BibleSubjectKey = 11,
                            BibleSubjectDescription = "열왕기상",
                            BibleSubjectName = "왕상"
                        },
                        new
                        {
                            BibleSubjectKey = 12,
                            BibleSubjectDescription = "열왕기하",
                            BibleSubjectName = "왕하"
                        },
                        new
                        {
                            BibleSubjectKey = 13,
                            BibleSubjectDescription = "역대상",
                            BibleSubjectName = "대상"
                        },
                        new
                        {
                            BibleSubjectKey = 14,
                            BibleSubjectDescription = "역대하",
                            BibleSubjectName = "대하"
                        },
                        new
                        {
                            BibleSubjectKey = 15,
                            BibleSubjectDescription = "에스라",
                            BibleSubjectName = "스"
                        },
                        new
                        {
                            BibleSubjectKey = 16,
                            BibleSubjectDescription = "느헤미야",
                            BibleSubjectName = "느"
                        },
                        new
                        {
                            BibleSubjectKey = 17,
                            BibleSubjectDescription = "에스더",
                            BibleSubjectName = "에"
                        },
                        new
                        {
                            BibleSubjectKey = 18,
                            BibleSubjectDescription = "욥기",
                            BibleSubjectName = "욥"
                        },
                        new
                        {
                            BibleSubjectKey = 19,
                            BibleSubjectDescription = "시편",
                            BibleSubjectName = "시"
                        },
                        new
                        {
                            BibleSubjectKey = 20,
                            BibleSubjectDescription = "잠언",
                            BibleSubjectName = "잠"
                        },
                        new
                        {
                            BibleSubjectKey = 21,
                            BibleSubjectDescription = "전도서",
                            BibleSubjectName = "전"
                        },
                        new
                        {
                            BibleSubjectKey = 22,
                            BibleSubjectDescription = "아가",
                            BibleSubjectName = "아"
                        },
                        new
                        {
                            BibleSubjectKey = 23,
                            BibleSubjectDescription = "이사야",
                            BibleSubjectName = "사"
                        },
                        new
                        {
                            BibleSubjectKey = 24,
                            BibleSubjectDescription = "예레미야",
                            BibleSubjectName = "렘"
                        },
                        new
                        {
                            BibleSubjectKey = 25,
                            BibleSubjectDescription = "예레미아애가",
                            BibleSubjectName = "애"
                        },
                        new
                        {
                            BibleSubjectKey = 26,
                            BibleSubjectDescription = "에스겔",
                            BibleSubjectName = "겔"
                        },
                        new
                        {
                            BibleSubjectKey = 27,
                            BibleSubjectDescription = "다니엘",
                            BibleSubjectName = "단"
                        },
                        new
                        {
                            BibleSubjectKey = 28,
                            BibleSubjectDescription = "호세아",
                            BibleSubjectName = "호"
                        },
                        new
                        {
                            BibleSubjectKey = 29,
                            BibleSubjectDescription = "요엘",
                            BibleSubjectName = "욜"
                        },
                        new
                        {
                            BibleSubjectKey = 30,
                            BibleSubjectDescription = "아모스",
                            BibleSubjectName = "암"
                        },
                        new
                        {
                            BibleSubjectKey = 31,
                            BibleSubjectDescription = "오바댜",
                            BibleSubjectName = "옵"
                        },
                        new
                        {
                            BibleSubjectKey = 32,
                            BibleSubjectDescription = "요나",
                            BibleSubjectName = "욘"
                        },
                        new
                        {
                            BibleSubjectKey = 33,
                            BibleSubjectDescription = "미가",
                            BibleSubjectName = "미"
                        },
                        new
                        {
                            BibleSubjectKey = 34,
                            BibleSubjectDescription = "나훔",
                            BibleSubjectName = "나"
                        },
                        new
                        {
                            BibleSubjectKey = 35,
                            BibleSubjectDescription = "하박국",
                            BibleSubjectName = "합"
                        },
                        new
                        {
                            BibleSubjectKey = 36,
                            BibleSubjectDescription = "스바냐",
                            BibleSubjectName = "습"
                        },
                        new
                        {
                            BibleSubjectKey = 37,
                            BibleSubjectDescription = "학개",
                            BibleSubjectName = "학"
                        },
                        new
                        {
                            BibleSubjectKey = 38,
                            BibleSubjectDescription = "스가랴",
                            BibleSubjectName = "슥"
                        },
                        new
                        {
                            BibleSubjectKey = 39,
                            BibleSubjectDescription = "말라기",
                            BibleSubjectName = "말"
                        },
                        new
                        {
                            BibleSubjectKey = 40,
                            BibleSubjectDescription = "마태복음",
                            BibleSubjectName = "마"
                        },
                        new
                        {
                            BibleSubjectKey = 41,
                            BibleSubjectDescription = "마가복음",
                            BibleSubjectName = "막"
                        },
                        new
                        {
                            BibleSubjectKey = 42,
                            BibleSubjectDescription = "누가복음",
                            BibleSubjectName = "눅"
                        },
                        new
                        {
                            BibleSubjectKey = 43,
                            BibleSubjectDescription = "요한복음",
                            BibleSubjectName = "요"
                        },
                        new
                        {
                            BibleSubjectKey = 44,
                            BibleSubjectDescription = "사도행전",
                            BibleSubjectName = "행"
                        },
                        new
                        {
                            BibleSubjectKey = 45,
                            BibleSubjectDescription = "로마서",
                            BibleSubjectName = "롬"
                        },
                        new
                        {
                            BibleSubjectKey = 46,
                            BibleSubjectDescription = "고린도전서",
                            BibleSubjectName = "고전"
                        },
                        new
                        {
                            BibleSubjectKey = 47,
                            BibleSubjectDescription = "고린도후서",
                            BibleSubjectName = "고후"
                        },
                        new
                        {
                            BibleSubjectKey = 48,
                            BibleSubjectDescription = "갈라디아서",
                            BibleSubjectName = "갈"
                        },
                        new
                        {
                            BibleSubjectKey = 49,
                            BibleSubjectDescription = "에베소서",
                            BibleSubjectName = "엡"
                        },
                        new
                        {
                            BibleSubjectKey = 50,
                            BibleSubjectDescription = "빌립보서",
                            BibleSubjectName = "빌"
                        },
                        new
                        {
                            BibleSubjectKey = 51,
                            BibleSubjectDescription = "골로새서",
                            BibleSubjectName = "골"
                        },
                        new
                        {
                            BibleSubjectKey = 52,
                            BibleSubjectDescription = "데살로니가전서",
                            BibleSubjectName = "살전"
                        },
                        new
                        {
                            BibleSubjectKey = 53,
                            BibleSubjectDescription = "데살로니가후서",
                            BibleSubjectName = "살후"
                        },
                        new
                        {
                            BibleSubjectKey = 54,
                            BibleSubjectDescription = "디모데전서",
                            BibleSubjectName = "딤전"
                        },
                        new
                        {
                            BibleSubjectKey = 55,
                            BibleSubjectDescription = "디모데후서",
                            BibleSubjectName = "딤후"
                        },
                        new
                        {
                            BibleSubjectKey = 56,
                            BibleSubjectDescription = "디도서",
                            BibleSubjectName = "딛"
                        },
                        new
                        {
                            BibleSubjectKey = 57,
                            BibleSubjectDescription = "빌레몬서",
                            BibleSubjectName = "몬"
                        },
                        new
                        {
                            BibleSubjectKey = 58,
                            BibleSubjectDescription = "히브리서",
                            BibleSubjectName = "히"
                        },
                        new
                        {
                            BibleSubjectKey = 59,
                            BibleSubjectDescription = "야고보서",
                            BibleSubjectName = "약"
                        },
                        new
                        {
                            BibleSubjectKey = 60,
                            BibleSubjectDescription = "베드로전서",
                            BibleSubjectName = "벧전"
                        },
                        new
                        {
                            BibleSubjectKey = 61,
                            BibleSubjectDescription = "베드로후서",
                            BibleSubjectName = "벧후"
                        },
                        new
                        {
                            BibleSubjectKey = 62,
                            BibleSubjectDescription = "요한1서",
                            BibleSubjectName = "요일"
                        },
                        new
                        {
                            BibleSubjectKey = 63,
                            BibleSubjectDescription = "요한2서",
                            BibleSubjectName = "요이"
                        },
                        new
                        {
                            BibleSubjectKey = 64,
                            BibleSubjectDescription = "요한3서",
                            BibleSubjectName = "요삼"
                        },
                        new
                        {
                            BibleSubjectKey = 65,
                            BibleSubjectDescription = "유다서",
                            BibleSubjectName = "유"
                        },
                        new
                        {
                            BibleSubjectKey = 66,
                            BibleSubjectDescription = "요한계시록",
                            BibleSubjectName = "계"
                        });
                });

            modelBuilder.Entity("BibleViewer.Context.BibleType", b =>
                {
                    b.Property<int>("BibleTypeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BibleTypeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("BibleTypeKey");

                    b.ToTable("BibleType");

                    b.HasData(
                        new
                        {
                            BibleTypeKey = 1,
                            BibleTypeName = "개역개정"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

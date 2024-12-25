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
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("BibleViewer.Entity.BibleSubject", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.HasIndex("Index");

                    b.ToTable("BibleSubject");

                    b.HasData(
                        new
                        {
                            Code = "gen",
                            Index = 0,
                            Name = "창세기",
                            ShortName = "창"
                        },
                        new
                        {
                            Code = "exo",
                            Index = 1,
                            Name = "출애굽기",
                            ShortName = "출"
                        },
                        new
                        {
                            Code = "lev",
                            Index = 2,
                            Name = "레위기",
                            ShortName = "레"
                        },
                        new
                        {
                            Code = "num",
                            Index = 3,
                            Name = "민수기",
                            ShortName = "민"
                        },
                        new
                        {
                            Code = "deu",
                            Index = 4,
                            Name = "신명기",
                            ShortName = "신"
                        },
                        new
                        {
                            Code = "jos",
                            Index = 5,
                            Name = "여호수아",
                            ShortName = "수"
                        },
                        new
                        {
                            Code = "jdg",
                            Index = 6,
                            Name = "사사기",
                            ShortName = "삿"
                        },
                        new
                        {
                            Code = "rut",
                            Index = 7,
                            Name = "룻기",
                            ShortName = "룻"
                        },
                        new
                        {
                            Code = "1sa",
                            Index = 8,
                            Name = "사무엘상",
                            ShortName = "삼상"
                        },
                        new
                        {
                            Code = "2sa",
                            Index = 9,
                            Name = "사무엘하",
                            ShortName = "삼하"
                        },
                        new
                        {
                            Code = "1ki",
                            Index = 10,
                            Name = "열왕기상",
                            ShortName = "왕상"
                        },
                        new
                        {
                            Code = "2ki",
                            Index = 11,
                            Name = "열왕기하",
                            ShortName = "왕하"
                        },
                        new
                        {
                            Code = "1ch",
                            Index = 12,
                            Name = "역대상",
                            ShortName = "대상"
                        },
                        new
                        {
                            Code = "2ch",
                            Index = 13,
                            Name = "역대하",
                            ShortName = "대하"
                        },
                        new
                        {
                            Code = "ezr",
                            Index = 14,
                            Name = "에스라",
                            ShortName = "스"
                        },
                        new
                        {
                            Code = "neh",
                            Index = 15,
                            Name = "느헤미야",
                            ShortName = "느"
                        },
                        new
                        {
                            Code = "est",
                            Index = 16,
                            Name = "에스더",
                            ShortName = "에"
                        },
                        new
                        {
                            Code = "job",
                            Index = 17,
                            Name = "욥기",
                            ShortName = "욥"
                        },
                        new
                        {
                            Code = "psa",
                            Index = 18,
                            Name = "시편",
                            ShortName = "시"
                        },
                        new
                        {
                            Code = "pro",
                            Index = 19,
                            Name = "잠언",
                            ShortName = "잠"
                        },
                        new
                        {
                            Code = "ecc",
                            Index = 20,
                            Name = "전도서",
                            ShortName = "전"
                        },
                        new
                        {
                            Code = "sng",
                            Index = 21,
                            Name = "아가",
                            ShortName = "아"
                        },
                        new
                        {
                            Code = "isa",
                            Index = 22,
                            Name = "이사야",
                            ShortName = "사"
                        },
                        new
                        {
                            Code = "jer",
                            Index = 23,
                            Name = "예레미야",
                            ShortName = "렘"
                        },
                        new
                        {
                            Code = "lam",
                            Index = 24,
                            Name = "예레미야애가",
                            ShortName = "애"
                        },
                        new
                        {
                            Code = "ezk",
                            Index = 25,
                            Name = "에스겔",
                            ShortName = "겔"
                        },
                        new
                        {
                            Code = "dan",
                            Index = 26,
                            Name = "다니엘",
                            ShortName = "단"
                        },
                        new
                        {
                            Code = "hos",
                            Index = 27,
                            Name = "호세아",
                            ShortName = "호"
                        },
                        new
                        {
                            Code = "jol",
                            Index = 28,
                            Name = "요엘",
                            ShortName = "욜"
                        },
                        new
                        {
                            Code = "amo",
                            Index = 29,
                            Name = "아모스",
                            ShortName = "암"
                        },
                        new
                        {
                            Code = "oba",
                            Index = 30,
                            Name = "오바댜",
                            ShortName = "옵"
                        },
                        new
                        {
                            Code = "jnh",
                            Index = 31,
                            Name = "요나",
                            ShortName = "욘"
                        },
                        new
                        {
                            Code = "mic",
                            Index = 32,
                            Name = "미가",
                            ShortName = "미"
                        },
                        new
                        {
                            Code = "nam",
                            Index = 33,
                            Name = "나훔",
                            ShortName = "나"
                        },
                        new
                        {
                            Code = "hab",
                            Index = 34,
                            Name = "하박국",
                            ShortName = "합"
                        },
                        new
                        {
                            Code = "zep",
                            Index = 35,
                            Name = "스바냐",
                            ShortName = "습"
                        },
                        new
                        {
                            Code = "hag",
                            Index = 36,
                            Name = "학개",
                            ShortName = "학"
                        },
                        new
                        {
                            Code = "zec",
                            Index = 37,
                            Name = "스가랴",
                            ShortName = "슥"
                        },
                        new
                        {
                            Code = "mal",
                            Index = 38,
                            Name = "말라기",
                            ShortName = "말"
                        },
                        new
                        {
                            Code = "mat",
                            Index = 39,
                            Name = "마태복음",
                            ShortName = "마"
                        },
                        new
                        {
                            Code = "mrk",
                            Index = 40,
                            Name = "마가복음",
                            ShortName = "막"
                        },
                        new
                        {
                            Code = "luk",
                            Index = 41,
                            Name = "누가복음",
                            ShortName = "눅"
                        },
                        new
                        {
                            Code = "jhn",
                            Index = 42,
                            Name = "요한복음",
                            ShortName = "요"
                        },
                        new
                        {
                            Code = "act",
                            Index = 43,
                            Name = "사도행전",
                            ShortName = "행"
                        },
                        new
                        {
                            Code = "rom",
                            Index = 44,
                            Name = "로마서",
                            ShortName = "롬"
                        },
                        new
                        {
                            Code = "1co",
                            Index = 45,
                            Name = "고린도전서",
                            ShortName = "고전"
                        },
                        new
                        {
                            Code = "2co",
                            Index = 46,
                            Name = "고린도후서",
                            ShortName = "고후"
                        },
                        new
                        {
                            Code = "gal",
                            Index = 47,
                            Name = "갈라디아서",
                            ShortName = "갈"
                        },
                        new
                        {
                            Code = "eph",
                            Index = 48,
                            Name = "에베소서",
                            ShortName = "엡"
                        },
                        new
                        {
                            Code = "php",
                            Index = 49,
                            Name = "빌리보서",
                            ShortName = "빌"
                        },
                        new
                        {
                            Code = "col",
                            Index = 50,
                            Name = "골로새서",
                            ShortName = "골"
                        },
                        new
                        {
                            Code = "1th",
                            Index = 51,
                            Name = "데살로니가전서",
                            ShortName = "살전"
                        },
                        new
                        {
                            Code = "2th",
                            Index = 52,
                            Name = "데살로니가후서",
                            ShortName = "살후"
                        },
                        new
                        {
                            Code = "1ti",
                            Index = 53,
                            Name = "디모데전서",
                            ShortName = "딤전"
                        },
                        new
                        {
                            Code = "2ti",
                            Index = 54,
                            Name = "디모데후서",
                            ShortName = "딤후"
                        },
                        new
                        {
                            Code = "tit",
                            Index = 55,
                            Name = "디도서",
                            ShortName = "딛"
                        },
                        new
                        {
                            Code = "phm",
                            Index = 56,
                            Name = "빌레몬서",
                            ShortName = "몬"
                        },
                        new
                        {
                            Code = "heb",
                            Index = 57,
                            Name = "히브리서",
                            ShortName = "히"
                        },
                        new
                        {
                            Code = "jas",
                            Index = 58,
                            Name = "야고보서",
                            ShortName = "약"
                        },
                        new
                        {
                            Code = "1pe",
                            Index = 59,
                            Name = "베드로전서",
                            ShortName = "벧전"
                        },
                        new
                        {
                            Code = "2pe",
                            Index = 60,
                            Name = "베드로후서",
                            ShortName = "벧후"
                        },
                        new
                        {
                            Code = "1jn",
                            Index = 61,
                            Name = "요한1서",
                            ShortName = "요일"
                        },
                        new
                        {
                            Code = "2jn",
                            Index = 62,
                            Name = "요한2서",
                            ShortName = "요이"
                        },
                        new
                        {
                            Code = "3jn",
                            Index = 63,
                            Name = "요한3서",
                            ShortName = "요삼"
                        },
                        new
                        {
                            Code = "jud",
                            Index = 64,
                            Name = "유다서",
                            ShortName = "유"
                        },
                        new
                        {
                            Code = "rev",
                            Index = 65,
                            Name = "요한계시록",
                            ShortName = "계"
                        });
                });

            modelBuilder.Entity("BibleViewer.Entity.BibleType", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.HasIndex("Index");

                    b.ToTable("BibleType");

                    b.HasData(
                        new
                        {
                            Code = "GAE",
                            Index = 0,
                            Name = "개역개정"
                        },
                        new
                        {
                            Code = "HAN",
                            Index = 1,
                            Name = "개역한글"
                        },
                        new
                        {
                            Code = "SAE",
                            Index = 2,
                            Name = "표준새번역"
                        },
                        new
                        {
                            Code = "SAENEW",
                            Index = 3,
                            Name = "새번역"
                        },
                        new
                        {
                            Code = "COG",
                            Index = 4,
                            Name = "공동번역"
                        },
                        new
                        {
                            Code = "COGNEW",
                            Index = 5,
                            Name = "공동번역 개정판"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

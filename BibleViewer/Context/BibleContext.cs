using Microsoft.EntityFrameworkCore;

namespace BibleViewer.Context
{
	using Entity;

	public class BibleContext(DbContextOptions<BibleContext> dbContextOptions) : DbContext(dbContextOptions)
	{
		public const string FILE_PATH = "Meta.db";
		public virtual DbSet<BibleType> BibleType { get; set; }
		public virtual DbSet<BibleSubject> BibleSubject { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BibleType>().HasKey(k => k.Code);
			modelBuilder.Entity<BibleType>().Property(p => p.Index).IsRequired();
			modelBuilder.Entity<BibleType>().Property(p => p.Code).HasMaxLength(6).IsRequired();
			modelBuilder.Entity<BibleType>().Property(p => p.Name).HasMaxLength(20).IsRequired();
			modelBuilder.Entity<BibleType>().HasIndex(p => p.Index).IsDescending(false);
			modelBuilder.Entity<BibleType>().HasData(new BibleType
			{
				Index = 0,
				Code = "GAE",
				Name = "개역개정"
			});
			modelBuilder.Entity<BibleType>().HasData(new BibleType
			{
				Index = 1,
				Code = "HAN",
				Name = "개역한글"
			});
			modelBuilder.Entity<BibleType>().HasData(new BibleType
			{
				Index = 2,
				Code = "SAE",
				Name = "표준새번역"
			});
			modelBuilder.Entity<BibleType>().HasData(new BibleType
			{
				Index = 3,
				Code = "SAENEW",
				Name = "새번역"
			});
			modelBuilder.Entity<BibleType>().HasData(new BibleType
			{
				Index = 4,
				Code = "COG",
				Name = "공동번역"
			});
			modelBuilder.Entity<BibleType>().HasData(new BibleType
			{
				Index = 5,
				Code = "COGNEW",
				Name = "공동번역 개정판"
			});

			modelBuilder.Entity<BibleSubject>().HasKey(k => k.Code);
			modelBuilder.Entity<BibleSubject>().Property(p => p.Index).IsRequired();
			modelBuilder.Entity<BibleSubject>().Property(p => p.Code).HasMaxLength(3).IsRequired();
			modelBuilder.Entity<BibleSubject>().Property(p => p.Name).HasMaxLength(20).IsRequired();
			modelBuilder.Entity<BibleSubject>().HasIndex(p => p.Index).IsDescending(false);
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(0, "gen", "창", "창세기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(1, "exo", "출", "출애굽기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(2, "lev", "레", "레위기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(3, "num", "민", "민수기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(4, "deu", "신", "신명기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(5, "jos", "수", "여호수아"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(6, "jdg", "삿", "사사기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(7, "rut", "룻", "룻기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(8, "1sa", "삼상", "사무엘상"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(9, "2sa", "삼하", "사무엘하"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(10, "1ki", "왕상", "열왕기상"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(11, "2ki", "왕하", "열왕기하"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(12, "1ch", "대상", "역대상"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(13, "2ch", "대하", "역대하"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(14, "ezr", "스", "에스라"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(15, "neh", "느", "느헤미야"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(16, "est", "에", "에스더"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(17, "job", "욥", "욥기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(18, "psa", "시", "시편"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(19, "pro", "잠", "잠언"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(20, "ecc", "전", "전도서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(21, "sng", "아", "아가"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(22, "isa", "사", "이사야"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(23, "jer", "렘", "예레미야"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(24, "lam", "애", "예레미야애가"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(25, "ezk", "겔", "에스겔"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(26, "dan", "단", "다니엘"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(27, "hos", "호", "호세아"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(28, "jol", "욜", "요엘"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(29, "amo", "암", "아모스"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(30, "oba", "옵", "오바댜"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(31, "jnh", "욘", "요나"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(32, "mic", "미", "미가"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(33, "nam", "나", "나훔"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(34, "hab", "합", "하박국"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(35, "zep", "습", "스바냐"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(36, "hag", "학", "학개"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(37, "zec", "슥", "스가랴"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(38, "mal", "말", "말라기"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(39, "mat", "마", "마태복음"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(40, "mrk", "막", "마가복음"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(41, "luk", "눅", "누가복음"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(42, "jhn", "요", "요한복음"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(43, "act", "행", "사도행전"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(44, "rom", "롬", "로마서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(45, "1co", "고전", "고린도전서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(46, "2co", "고후", "고린도후서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(47, "gal", "갈", "갈라디아서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(48, "eph", "엡", "에베소서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(49, "php", "빌", "빌리보서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(50, "col", "골", "골로새서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(51, "1th", "살전", "데살로니가전서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(52, "2th", "살후", "데살로니가후서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(53, "1ti", "딤전", "디모데전서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(54, "2ti", "딤후", "디모데후서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(55, "tit", "딛", "디도서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(56, "phm", "몬", "빌레몬서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(57, "heb", "히", "히브리서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(58, "jas", "약", "야고보서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(59, "1pe", "벧전", "베드로전서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(60, "2pe", "벧후", "베드로후서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(61, "1jn", "요일", "요한1서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(62, "2jn", "요이", "요한2서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(63, "3jn", "요삼", "요한3서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(64, "jud", "유", "유다서"));
			modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject(65, "rev", "계", "요한계시록"));

			base.OnModelCreating(modelBuilder);
		}
	}
}

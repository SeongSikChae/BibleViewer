using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace BibleViewer.Context
{
	public class BibleContext : DbContext
	{
		public BibleContext(DbContextOptions<BibleContext> dbContextOptions) : base(dbContextOptions) { }

		public virtual DbSet<BibleType> BibleType { get; set; }
		public virtual DbSet<BibleSubject> BibleSubject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BibleType>().HasKey(k => k.BibleTypeKey);
            modelBuilder.Entity<BibleType>().Property(p => p.BibleTypeKey).IsRequired();
            modelBuilder.Entity<BibleType>().Property(p => p.BibleTypeName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<BibleType>().HasData(new BibleType
            {
                BibleTypeKey = 1,
                BibleTypeName = "개역개정"
            });

            modelBuilder.Entity<BibleSubject>().HasKey(k => k.BibleSubjectKey);
            modelBuilder.Entity<BibleSubject>().Property(p => p.BibleSubjectName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<BibleSubject>().Property(p => p.BibleSubjectDescription).IsRequired().HasMaxLength(20);

            using StreamReader reader = new StreamReader(new BufferedStream(new FileStream("Data\\Subject.txt", FileMode.Open, FileAccess.Read)));
            while (true)
            {
                string line = reader.ReadLine();
                if (line is null)
                    break;
                string[] block = line.Split(':');
                modelBuilder.Entity<BibleSubject>().HasData(new BibleSubject
                {
                    BibleSubjectKey = int.Parse(block[2]),
                    BibleSubjectName = block[0],
                    BibleSubjectDescription = block[1]
                });
            }

            base.OnModelCreating(modelBuilder);
        }
    }

  [Table("BibleType")]
  public sealed class BibleType
  {
    [Key]
    public int BibleTypeKey { get; set; }

    [Required, StringLength(20)]
    public string BibleTypeName { get; set; }
  }

  [Table("BibleSubject")]
  public sealed class BibleSubject
  {
    [Key]
    public int BibleSubjectKey { get; set; }

    [Required, StringLength(20)]
    public string BibleSubjectName { get; set; }

    [Required, StringLength(20)]
    public string BibleSubjectDescription { get; set; }
  }

  public sealed class BibleChapter
  {
    public int BibleType { get; set; }

    public int BibleSubject { get; set; }

    public int ChapterNumber { get; set; }

    public int LineNumber { get; set; }

    public string Body { get; set; }
  }
}

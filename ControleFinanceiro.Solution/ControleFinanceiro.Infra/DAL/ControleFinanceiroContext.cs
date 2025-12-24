using ControleFinanceiro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.DAL;
//Classe para configurar o contexto do banco de dados via entity framework
public partial class ControleFinanceiroContext : DbContext
{
    public ControleFinanceiroContext()
    {
    }

    public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Pessoa> Pessoas { get; set; }
    public virtual DbSet<Transaco> Transacoes { get; set; }

    //Name=ConnectionStrings:Chinook
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(""); //resgate da connection string do appsettings.json, e util para fazer as migrations quando necessario.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__DD5DDDBDB4C6B17A");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CatDescricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cat_descricao");
            entity.Property(e => e.CatFinalidade).HasColumnName("cat_finalidade");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.PesId).HasName("PK__Pessoas__410B66F8CB6BFB3B");

            entity.Property(e => e.PesId).HasColumnName("pes_id");
            entity.Property(e => e.PesIdade).HasColumnName("pes_idade");
            entity.Property(e => e.PesNome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("pes_nome");
        });

        modelBuilder.Entity<Transaco>(entity =>
        {
            entity.HasKey(e => e.TraId).HasName("PK__Transaco__9E078C13C03A993F");

            entity.Property(e => e.TraId).HasColumnName("tra_id");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.PesId).HasColumnName("pes_id");
            entity.Property(e => e.TraDescricao)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("tra_descricao");
            entity.Property(e => e.TraTipo).HasColumnName("tra_tipo");
            entity.Property(e => e.TraValor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tra_valor");

            entity.HasOne(d => d.Cat).WithMany(p => p.Transacos)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transacoes_Categorias");

            entity.HasOne(d => d.Pes).WithMany(p => p.Transacos)
                .HasForeignKey(d => d.PesId)
                .HasConstraintName("FK_Transacoes_Pessoas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

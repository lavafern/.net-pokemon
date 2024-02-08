using Microsoft.EntityFrameworkCore;
using pokemon.Models;

namespace pokemon.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

        public DbSet<Element> Elements { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<ElementOnPokemon> ElementOnPokemons { get; set; }
        public DbSet<OwnerOnPokemon> OwnerOnPokemons { get; set; }
        public DbSet<ReviewOnPokemon> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElementOnPokemon>()
                .HasKey(ep => new { ep.ElementId, ep.PokemonId });
            modelBuilder.Entity<ElementOnPokemon>()
                .HasOne(e => e.Element)
                .WithMany(ep => ep.ElementOnPokemons)
                .HasForeignKey(e => e.ElementId);
            modelBuilder.Entity<ElementOnPokemon>()
                .HasOne(p => p.Pokemon)
                .WithMany(ep => ep.ElementOnPokemons)
                .HasForeignKey(p => p.PokemonId);

            modelBuilder.Entity<OwnerOnPokemon>()
                .HasKey(op => new { op.OwnerId, op.PokemonId });
            modelBuilder.Entity<OwnerOnPokemon>()
                .HasOne(o => o.Owner)
                .WithMany(op => op.ownerOnPokemons)
                .HasForeignKey(o => o.OwnerId);
            modelBuilder.Entity<OwnerOnPokemon>()
                .HasOne(p => p.Pokemon)
                .WithMany(op => op.OwnerOnPokemons)
                .HasForeignKey(p => p.PokemonId);

            modelBuilder.Entity<ReviewOnPokemon>()
                .HasKey(rp => new { rp.ReviewerId, rp.PokemonId });
            modelBuilder.Entity<ReviewOnPokemon>()
                .HasOne(r => r.Reviewer)
                .WithMany(rp => rp.ReviewOnPokemons)
                .HasForeignKey(r => r.ReviewerId);
            modelBuilder.Entity<ReviewOnPokemon>()
                .HasOne(p => p.Pokemon)
                .WithMany(rp => rp.ReviewOnPokemons)
                .HasForeignKey(p => p.PokemonId);


        }


    }
}

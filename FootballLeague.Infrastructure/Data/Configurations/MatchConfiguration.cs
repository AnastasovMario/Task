﻿namespace FootballLeague.Infrastructure.Data.Configurations
{
  public class MatchConfiguration : IEntityTypeConfiguration<Match>
  {
    public void Configure(EntityTypeBuilder<Match> builder)
    {
      builder.HasKey(m => m.Id);
      builder.Property(m => m.DatePlayed)
          .IsRequired();

      builder.HasOne(m => m.HomeTeam)
          .WithMany()
          .HasForeignKey(m => m.HomeTeamId)
          .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(m => m.AwayTeam)
          .WithMany()
          .HasForeignKey(m => m.AwayTeamId)
          .OnDelete(DeleteBehavior.Restrict);
    }
  }
}

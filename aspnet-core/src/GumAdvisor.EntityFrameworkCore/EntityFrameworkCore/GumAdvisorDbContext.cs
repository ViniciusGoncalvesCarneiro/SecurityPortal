using Abp.IdentityServer4vNext;
using Abp.Zero.EntityFrameworkCore;
using GumAdvisor.Authorization.Delegation;
using GumAdvisor.Authorization.Roles;
using GumAdvisor.Authorization.Users;
using GumAdvisor.Chat;
using GumAdvisor.Editions;
using GumAdvisor.Friendships;
using GumAdvisor.MultiTenancy;
using GumAdvisor.MultiTenancy.Accounting;
using GumAdvisor.MultiTenancy.Payments;
using GumAdvisor.Storage;
using GumAdvisor.SystemSurvey;
using Microsoft.EntityFrameworkCore;

namespace GumAdvisor.EntityFrameworkCore
{
    public class GumAdvisorDbContext : AbpZeroDbContext<Tenant, Role, User, GumAdvisorDbContext>, IAbpPersistedGrantDbContext
    {
        public virtual DbSet<Iso> Iso { get; set; }
        public virtual DbSet<Mitre> Mitre { get; set; }
        public virtual DbSet<Nist> Nist { get; set; }
        public virtual DbSet<CisToIso> CisToIso { get; set; }
        public virtual DbSet<CisToMitre> CisToMitre { get; set; }
        public virtual DbSet<CisToNist> CisToNist { get; set; }

        /* Define an IDbSet for each entity of the application */
        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }
        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }
        public virtual DbSet<UserDelegation> UserDelegations { get; set; }
        public virtual DbSet<RecentPassword> RecentPasswords { get; set; }

        public GumAdvisorDbContext(DbContextOptions<GumAdvisorDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Iso>(b => { b.HasIndex(e => new { e.TenantId }); });
            modelBuilder.Entity<Mitre>(b => { b.HasIndex(e => new { e.TenantId }); });
            modelBuilder.Entity<Nist>(b => { b.HasIndex(e => new { e.TenantId }); });
            modelBuilder.Entity<CisToIso>(b => { b.HasIndex(e => new { e.TenantId }); });
            modelBuilder.Entity<CisToMitre>(b => { b.HasIndex(e => new { e.TenantId }); });
            modelBuilder.Entity<CisToNist>(b => { b.HasIndex(e => new { e.TenantId }); });


            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}

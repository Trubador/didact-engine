﻿// <auto-generated />
using System;
using DidactEngine.Services.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DidactEngine.Migrations
{
    [DbContext(typeof(DidactDbContext))]
    [Migration("20231210080814_AddEngineConfiguration")]
    partial class AddEngineConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DidactEngine.Models.Entities.BlockRun", b =>
                {
                    b.Property<long>("BlockRunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BlockRunId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BlockName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExecutionEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExecutionStarted")
                        .HasColumnType("datetime2");

                    b.Property<long>("FlowRunId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StateLastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("StateLastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlockRunId");

                    b.HasIndex("FlowRunId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("StateId");

                    b.ToTable("BlockRun");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Engine", b =>
                {
                    b.Property<int>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EngineId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EngineId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Engine", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FifoQueue", b =>
                {
                    b.Property<int>("FifoQueueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FifoQueueId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("FifoQueueId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("FifoQueue", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FifoQueueInbound", b =>
                {
                    b.Property<long>("FifoQueueInboundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FifoQueueInboundId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("FifoQueueId")
                        .HasColumnType("int");

                    b.Property<long>("FlowRunId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("FifoQueueInboundId");

                    b.HasIndex("FifoQueueId");

                    b.HasIndex("FlowRunId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("FifoQueueInbound", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Flow", b =>
                {
                    b.Property<long>("FlowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FlowId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("AssemblyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConcurrencyLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullyQualifiedTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Version")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FlowId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Flow", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FlowRun", b =>
                {
                    b.Property<long>("FlowRunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FlowRunId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExecuteAfter")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExecutionEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExecutionStarted")
                        .HasColumnType("datetime2");

                    b.Property<long>("FlowId")
                        .HasColumnType("bigint");

                    b.Property<string>("JsonPayload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<long?>("ParentFlowRunId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TimeoutSeconds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TriggerTypeId")
                        .HasColumnType("int");

                    b.HasKey("FlowRunId");

                    b.HasIndex("FlowId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("StateId");

                    b.HasIndex("TriggerTypeId");

                    b.ToTable("FlowRun", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FlowSchedule", b =>
                {
                    b.Property<long>("FlowScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FlowScheduleId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CronExpression")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("FlowId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastRunTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("NextRunTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("ScheduleTypeId")
                        .HasColumnType("int");

                    b.HasKey("FlowScheduleId");

                    b.HasIndex("FlowId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ScheduleTypeId");

                    b.ToTable("FlowSchedule", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.HyperQueue", b =>
                {
                    b.Property<int>("HyperQueueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HyperQueueId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("HyperQueueId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("HyperQueue", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.HyperQueueInbound", b =>
                {
                    b.Property<long>("HyperQueueInboundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("HyperQueueInboundId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("FlowRunId")
                        .HasColumnType("bigint");

                    b.Property<int>("HyperQueueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("HyperQueueInboundId");

                    b.HasIndex("FlowRunId");

                    b.HasIndex("HyperQueueId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("HyperQueueInbound", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organization", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.ScheduleType", b =>
                {
                    b.Property<int>("ScheduleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleTypeId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ScheduleTypeId");

                    b.ToTable("ScheduleType", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("StateId");

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.TriggerType", b =>
                {
                    b.Property<int>("TriggerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TriggerTypeId"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("TriggerTypeId");

                    b.ToTable("TriggerType", (string)null);
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.BlockRun", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.FlowRun", "FlowRun")
                        .WithMany("BlockRuns")
                        .HasForeignKey("FlowRunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("BlockRuns")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DidactEngine.Models.Entities.State", "State")
                        .WithMany("BlockRuns")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlowRun");

                    b.Navigation("Organization");

                    b.Navigation("State");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Engine", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("Engines")
                        .HasForeignKey("OrganizationId")
                        .IsRequired()
                        .HasConstraintName("FK_Engine_Organization");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FifoQueue", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("FifoQueues")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FifoQueueInbound", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.FifoQueue", "FifoQueue")
                        .WithMany("FifoQueueInbounds")
                        .HasForeignKey("FifoQueueId")
                        .IsRequired()
                        .HasConstraintName("FK_FifoQueueInbound_FifoQueue");

                    b.HasOne("DidactEngine.Models.Entities.FlowRun", "FlowRun")
                        .WithMany("FifoQueueInbounds")
                        .HasForeignKey("FlowRunId")
                        .IsRequired()
                        .HasConstraintName("FK_FifoQueueInbound_FlowRun");

                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("FifoQueueInbounds")
                        .HasForeignKey("OrganizationId")
                        .IsRequired()
                        .HasConstraintName("FK_FifoQueueInbound_Organization");

                    b.Navigation("FifoQueue");

                    b.Navigation("FlowRun");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Flow", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("Flows")
                        .HasForeignKey("OrganizationId")
                        .IsRequired()
                        .HasConstraintName("FK_Flow_Organization");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FlowRun", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.Flow", "Flow")
                        .WithMany("FlowRuns")
                        .HasForeignKey("FlowId")
                        .IsRequired()
                        .HasConstraintName("FK_FlowRun_Flow");

                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("FlowRuns")
                        .HasForeignKey("OrganizationId")
                        .IsRequired()
                        .HasConstraintName("FK_FlowRun_Organization");

                    b.HasOne("DidactEngine.Models.Entities.State", "State")
                        .WithMany("FlowRuns")
                        .HasForeignKey("StateId")
                        .IsRequired()
                        .HasConstraintName("FK_FlowRun_State");

                    b.HasOne("DidactEngine.Models.Entities.TriggerType", "TriggerType")
                        .WithMany("FlowRuns")
                        .HasForeignKey("TriggerTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_FlowRun_TriggerType");

                    b.Navigation("Flow");

                    b.Navigation("Organization");

                    b.Navigation("State");

                    b.Navigation("TriggerType");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FlowSchedule", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.Flow", "Flow")
                        .WithMany()
                        .HasForeignKey("FlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DidactEngine.Models.Entities.ScheduleType", "ScheduleType")
                        .WithMany()
                        .HasForeignKey("ScheduleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flow");

                    b.Navigation("Organization");

                    b.Navigation("ScheduleType");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.HyperQueue", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("HyperQueues")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.HyperQueueInbound", b =>
                {
                    b.HasOne("DidactEngine.Models.Entities.FlowRun", "FlowRun")
                        .WithMany("HyperQueueInbounds")
                        .HasForeignKey("FlowRunId")
                        .IsRequired()
                        .HasConstraintName("FK_HyperQueueInbound_FlowRun");

                    b.HasOne("DidactEngine.Models.Entities.HyperQueue", "HyperQueue")
                        .WithMany("HyperQueueInbounds")
                        .HasForeignKey("HyperQueueId")
                        .IsRequired()
                        .HasConstraintName("FK_HyperQueueInbound_$HyperQueue");

                    b.HasOne("DidactEngine.Models.Entities.Organization", "Organization")
                        .WithMany("HyperQueueInbounds")
                        .HasForeignKey("OrganizationId")
                        .IsRequired()
                        .HasConstraintName("FK_HyperQueueInbound_Organization");

                    b.Navigation("FlowRun");

                    b.Navigation("HyperQueue");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FifoQueue", b =>
                {
                    b.Navigation("FifoQueueInbounds");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Flow", b =>
                {
                    b.Navigation("FlowRuns");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.FlowRun", b =>
                {
                    b.Navigation("BlockRuns");

                    b.Navigation("FifoQueueInbounds");

                    b.Navigation("HyperQueueInbounds");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.HyperQueue", b =>
                {
                    b.Navigation("HyperQueueInbounds");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.Organization", b =>
                {
                    b.Navigation("BlockRuns");

                    b.Navigation("Engines");

                    b.Navigation("FifoQueueInbounds");

                    b.Navigation("FifoQueues");

                    b.Navigation("FlowRuns");

                    b.Navigation("Flows");

                    b.Navigation("HyperQueueInbounds");

                    b.Navigation("HyperQueues");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.State", b =>
                {
                    b.Navigation("BlockRuns");

                    b.Navigation("FlowRuns");
                });

            modelBuilder.Entity("DidactEngine.Models.Entities.TriggerType", b =>
                {
                    b.Navigation("FlowRuns");
                });
#pragma warning restore 612, 618
        }
    }
}

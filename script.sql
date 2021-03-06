USE [QLCNH]
GO
/****** Object:  Table [dbo].[account]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[account_id] [uniqueidentifier] NOT NULL,
	[account_name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[is_admin] [int] NULL,
	[company_id] [uniqueidentifier] NULL,
	[branch_id] [uniqueidentifier] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](255) NULL,
	[modify_date] [datetime] NULL,
	[modify_by] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branch]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branch](
	[branch_id] [uniqueidentifier] NOT NULL,
	[branch_code] [varchar](50) NOT NULL,
	[branch_name] [nvarchar](255) NOT NULL,
	[is_parent] [int] NULL,
	[company_id] [uniqueidentifier] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](255) NULL,
	[modify_date] [datetime] NULL,
	[modify_by] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[branch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[company_id] [uniqueidentifier] NOT NULL,
	[company_code] [varchar](50) NOT NULL,
	[company_name] [nvarchar](255) NOT NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](255) NULL,
	[modify_date] [datetime] NULL,
	[modify_by] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customer_id] [uniqueidentifier] NOT NULL,
	[customer_code] [varchar](50) NOT NULL,
	[customer_name] [nvarchar](255) NOT NULL,
	[birthday] [date] NULL,
	[address] [nvarchar](255) NULL,
	[phone] [varchar](20) NULL,
	[mail] [varchar](255) NULL,
	[sex] [int] NULL,
	[customer_type] [int] NULL,
	[debt_amount] [bigint] NULL,
	[quanlity_buy] [int] NULL,
	[description] [nvarchar](500) NULL,
	[branch_id] [uniqueidentifier] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](255) NULL,
	[modify_date] [datetime] NULL,
	[modify_by] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[employee_id] [uniqueidentifier] NOT NULL,
	[employee_code] [varchar](50) NOT NULL,
	[employee_name] [nvarchar](255) NOT NULL,
	[birthday] [date] NULL,
	[address] [nvarchar](255) NULL,
	[phone] [varchar](20) NULL,
	[mail] [varchar](255) NULL,
	[salary] [bigint] NULL,
	[sex] [int] NULL,
	[position] [int] NULL,
	[department] [int] NULL,
	[tax_code] [varchar](50) NULL,
	[date_join] [date] NULL,
	[status] [int] NULL,
	[avatar_link] [nvarchar](max) NULL,
	[description] [nvarchar](500) NULL,
	[branch_id] [uniqueidentifier] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](255) NULL,
	[modify_date] [datetime] NULL,
	[modify_by] [nvarchar](255) NULL,
 CONSTRAINT [PK__employee__C52E0BA807ABF780] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendor]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendor](
	[vendor_id] [uniqueidentifier] NOT NULL,
	[vendor_code] [varchar](50) NOT NULL,
	[vendor_name] [nvarchar](255) NOT NULL,
	[address] [nvarchar](255) NULL,
	[phone] [varchar](20) NULL,
	[mail] [varchar](255) NULL,
	[tax_code] [varchar](50) NULL,
	[website] [varchar](250) NULL,
	[vendor_type] [int] NULL,
	[employee_id] [uniqueidentifier] NULL,
	[contact_vocative] [int] NULL,
	[contact_name] [nvarchar](255) NULL,
	[contact_email] [varchar](255) NULL,
	[contact_phone] [varchar](20) NULL,
	[contact_legal] [nvarchar](255) NULL,
	[debt_amount] [bigint] NULL,
	[debt_max_amount] [bigint] NULL,
	[debt_max_date] [int] NULL,
	[description] [nvarchar](500) NULL,
	[branch_id] [uniqueidentifier] NULL,
	[create_date] [datetime] NULL,
	[create_by] [nvarchar](255) NULL,
	[modify_date] [datetime] NULL,
	[modify_by] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[vendor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (newid()) FOR [account_id]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[branch] ADD  DEFAULT (newid()) FOR [branch_id]
GO
ALTER TABLE [dbo].[branch] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[company] ADD  DEFAULT (newid()) FOR [company_id]
GO
ALTER TABLE [dbo].[company] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (newid()) FOR [customer_id]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ((0)) FOR [sex]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[employee] ADD  CONSTRAINT [DF__employee__employ__24927208]  DEFAULT (newid()) FOR [employee_id]
GO
ALTER TABLE [dbo].[employee] ADD  CONSTRAINT [DF__employee__sex__25869641]  DEFAULT ((0)) FOR [sex]
GO
ALTER TABLE [dbo].[employee] ADD  CONSTRAINT [DF__employee__positi__267ABA7A]  DEFAULT ((0)) FOR [position]
GO
ALTER TABLE [dbo].[employee] ADD  CONSTRAINT [DF_employee_date_join]  DEFAULT (getdate()) FOR [date_join]
GO
ALTER TABLE [dbo].[employee] ADD  CONSTRAINT [DF__employee__create__276EDEB3]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[vendor] ADD  DEFAULT (newid()) FOR [vendor_id]
GO
ALTER TABLE [dbo].[vendor] ADD  DEFAULT (getdate()) FOR [create_date]
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetCustomer]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Proc_GetCustomer]
as
select * from dbo.customer
go;
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetEmployees]    Script Date: 28/6/2021 11:09:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Proc_GetEmployees]
as
select * from dbo.employee
go;
GO

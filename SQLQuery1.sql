CREATE TABLE [dbo].[DataServis] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name_Prepriat]        NVARCHAR (50) NULL,
    [Service_type]         NVARCHAR (50) NULL,
    [Service_cost_work]    DECIMAL (18)  NULL,
    [Service_cost_zapcast] DECIMAL (18)  NULL,
    [Name_engineer]        NVARCHAR (50) NULL,
    [Service_time]         DATE    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


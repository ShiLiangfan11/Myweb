-- 禁用所有外键约束
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

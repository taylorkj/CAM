CREATE VIEW [dbo].[IpAddressRanges_v]
	AS SELECT Distinct RangeId AS Id, (case when RangeId like '169.237.124' then 1
									when RangeId like '128.120.137' then 2
									when RangeId like '128.120.147' then 3
									end)  AS TabOrder FROM IpAddresses

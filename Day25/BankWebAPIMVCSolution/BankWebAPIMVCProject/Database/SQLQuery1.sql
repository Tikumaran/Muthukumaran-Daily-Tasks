use dbBank

select * from SBAccounts

select * from SBTransactions where Account_Number='2101'

ALTER TABLE SBTransactions
ADD FOREIGN KEY (Account_Number) REFERENCES SBAccounts(AccountNumber);

delete from SBAccounts where AccountNumber='2107'

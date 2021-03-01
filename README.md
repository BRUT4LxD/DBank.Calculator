# DBank.Calculator

## CLI parameters: 
- `-amount` - loan amount. Initial decimal value for calculations
- `-duration` - loan duration. Loan duration in year represented as integer value. 

Usage:
```.\DBank.Calculator.exe -amount 500000 -duration 10```
Sample Result:
```
****LOAN REPORT****


AOP: 12,7%
Monthly cost: 5.303,28 kr.
Total amount paid in interest rate: 136.393,09 kr.
Administration fee: 5.000,00 kr.

```

## Loan Configuration
Loan terms parameters are configurable in `app.config` file.
Additional parameters that was introduced to the project are:
- `InterestRate` - value that reflects annual interest rate. Represented as `double`. Sample value `0.05` is represented as 5%
- `Capitalization` - value that reflects capitalization rate. Capitalization may be: "Monthly", "Quarterly", "Yearly".  
- `Culture` - Culture-Language code. Sample "da-DK" 
- `LoanCalculationStrategy` - integer value that reflects a way of calculating the loan. `0` is `NoCalculationStrategy`, `1` is `StandardCalculationStrategy`
- `LoanAdministrationFeeStrategy` - integer value that reflects a way of calculating administration fee. `0` is `NoAdministrationFeeStrategy`, `1` is `StandardAdministrationFeeStrategy`
- `LoanReportStrategy` - integer value that reflects a way of displaying the reports of the loan. `0` is `NoReportStrategy`, `1` is `StandardReportStrategy`

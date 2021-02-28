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


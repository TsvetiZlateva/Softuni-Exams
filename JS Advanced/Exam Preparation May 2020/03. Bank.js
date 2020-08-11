//Problem 3. Bank

class Bank{
    constructor(bankName){
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer){
        if(this.allCustomers.find((c => c.firstName === customer.firstName) 
        && (c => c.lastName === customer.lastName)
        && (c => c.personalId === customer.personalId))){
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }
        else{
            this.allCustomers.push(customer);
            return customer;
        }
    }

    depositMoney(personalId, amount){
        if(!this.allCustomers.find(c => c.personalId === personalId)){
            throw new Error('We have no customer with this ID!');
        }
        else{
            let customer = this.allCustomers.find(c => c.personalId === personalId);
            if(customer.hasOwnProperty("totalMoney")){
                customer.totalMoney += amount;
            }
            else{
                customer.totalMoney = 0;
                customer.totalMoney += amount;
            }
            if(customer.hasOwnProperty("transactions")){
                customer.transactions.count++;
                customer.transactions.push(`${customer.transactions.count}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
            }
            else{
                customer.transactions = [];
                customer.transactions.count = 1;
                customer.transactions.push(`${customer.transactions.count}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);

            }
            return `${customer.totalMoney}$`;
            
        }
    }

    withdrawMoney(personalId, amount){
        if(!this.allCustomers.find(c => c.personalId === personalId)){
            throw new Error('We have no customer with this ID!');
        }
        else{
            let customer = this.allCustomers.find(c => c.personalId === personalId);
            if(!customer.totalMoney || customer.totalMoney < amount){
                throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
            }
            else{
                customer.totalMoney -= amount;

                if(customer.hasOwnProperty("transactions")){
                    customer.transactions.count++;
                    customer.transactions.push(`${customer.transactions.count}. ${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);
                }
                else{
                    customer.transactions = [];
                    customer.transactions.count = 1;
                    customer.transactions.push(`${customer.transactions.count}. ${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

                }
                return `${customer.totalMoney}$`;
            }
        }
    }

    customerInfo(personalId){
        if(!this.allCustomers.find(c => c.personalId === personalId)){
            throw new Error('We have no customer with this ID!');
        }
        else{
            let customer = this.allCustomers.find(c => c.personalId === personalId);

            return `Bank name: ${this._bankName}` + '\n' +
            `Customer name: ${customer.firstName} ${customer.lastName}` + '\n' +
            `Customer ID: ${customer.personalId}` + '\n' +
            `Total Money: ${customer.totalMoney}$` + '\n' +
            `Transactions:` + '\n' +
            `${customer.transactions.reverse().join('\n')}`.trim();            
        }
    }

}

// //let Bank = result;
// let name = 'SoftUni Bank';
// let bank = new Bank(name);


// let customer1 = bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 });
// //expect(customer1.firstName).to.be.equal('Svetlin');

// let customer2 = bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 3333333 });
// //expect(customer2.lastName).to.be.equal('Mileva');
// //expect(customer2.personalId).to.be.equal(3333333);

// let totalMoney1 = bank.depositMoney(1111111, 250);
// //expect(totalMoney1).to.be.equal('250$', 'Function depositMoney returns incorrect totalMoney');

// let totalMoney2 = bank.depositMoney(1111111, 250);
// //expect(totalMoney2).to.be.equal('500$', 'Function depositMoney returns incorrect totalMoney');

// let totalMoney3 = bank.depositMoney(3333333, 555);
// //expect(totalMoney3).to.be.equal('555$', 'Function depositMoney returns incorrect totalMoney');

// let totalMoney4 = bank.withdrawMoney(1111111, 125);
// //expect(totalMoney4).to.equal('375$', 'Function withdrawMoney returns incorrect totalMoney');

// let output = bank.customerInfo(1111111);
// let expectedOutput = `Bank name: SoftUni Bank
// Customer name: Svetlin Nakov
// Customer ID: 1111111
// Total Money: 375$
// Transactions:
// 3. Svetlin Nakov withdrew 125$!
// 2. Svetlin Nakov made deposit of 250$!
// 1. Svetlin Nakov made deposit of 250$!`;
// //expect(expectedOutput).to.be.equal(output, 'Incorrect output');

// console.log(output);



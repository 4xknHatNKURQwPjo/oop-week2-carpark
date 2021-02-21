using System;
using System.Collections.Generic;

namespace app {
    class Garage {
        private double baseFee;
        private double fee; 
        private double maxFee24Hrs;

        private List<Customer> customers;

        public Garage(double baseFee, double fee, double maxFee24Hrs) {
            this.baseFee = baseFee;
            this.fee = fee;
            this.maxFee24Hrs = maxFee24Hrs;

            this.customers = new List<Customer>();
        }

        public void add(Customer customer) {
            this.customers.Add(customer);
        }

        public void displayCharges() {
            double total = 0;
            for(int i = 0; i < this.customers.Count; i++) {
                double charge = calculateCharges(this.customers[i]);        
                Console.WriteLine($"{this.customers[i].name} owes €{string.Format("{0:0.00}", charge)}.");
                total += charge;
            }
            Console.WriteLine($"\nTotal charges: €{string.Format("{0:0.00}", total)}.");
        }

        public double totalCharges() {
            double charge = 0;
            for(int i = 0; i < this.customers.Count; i++) {
                charge += calculateCharges(this.customers[i]);        
            }
            return charge;
        }

        public double calculateCharges(Customer customer) {
            if(customer.hours <= 3) return this.baseFee;
            if(customer.hours >= 24) return this.maxFee24Hrs;

            double fee = this.baseFee + (customer.hours - 3) * this.fee;
			if(fee >= this.maxFee24Hrs) return this.maxFee24Hrs;
            return fee;
        }
    }
    
    class Customer {
        public string name;
        public int hours;

        public Customer(string name) {
            this.name = name;
        }

        public void setHours(int hours) {
            this.hours = hours;
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Garage garage = new Garage(2.0, .5, 10.0);

            Customer aurele = new Customer("Aurèle");
            garage.add(aurele);
            aurele.setHours(8);

            Customer brice = new Customer("Brice");
            garage.add(brice);
            brice.setHours(3);

            Customer loic = new Customer("Loïc");
            garage.add(loic);
            loic.setHours(24);


            for(int i = 0; i <= 25; i++) {
                Customer a = new Customer(i.ToString());
                garage.add(a);
                a.setHours(i);
            }


            
            garage.displayCharges();
        }
    }
}

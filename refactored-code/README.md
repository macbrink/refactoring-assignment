# Refactored Code

## Design

The provided code is about entering an applicant for an insurance, relevant information is required . The program assesses the eligibility of the applicant for an Insurance Cover. If the applicant is eligible, an insurance fee will be calculated.

## Observations about entities and relations
-   An insurance may have 0 to many subscribers
-   A Subscriber may have 1 to many insurances
-   We need an InsurancePolicy to connect Subcribers to Insurances
-   An InsuranbcePolicy has 1 Subscriber and 1 Insurance

### Properties
- An Insurance has an id, a name, a description and a base fee an zero or more InsurancePolicies
- A Subscriber has an id, a name, a date of birth, an email, a phone number, an address, a postal code, city, country and one or more InsurancePolicies
- An InsurancePolicy has an id, a subscriber, an insurance, a start date and an end date, a status, an insured amount and a fee

### Methods
- An InsuranceCalculator is used to calculate the fee of an InsurancePolicy
- An ApplicantValidator is used to validate the information of an applicant
- InsuranxceCalculators and ApplicantValidators are used by the InsurancePolicyService an may vary per Insurance.

### Rules
- An Applicant has to be validated before an Subscription can be made
- An insurance fee is calculated based on the information of the applicant and the insured amount

# Disclaimer 
- The provided code is a refactored version of the original code
- This is in no way a complete solution for an insurance company
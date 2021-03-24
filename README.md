# Roger Backend Take-home Test

Hi! We're super stoked that you're interested in working with us at Roger.

## Assignment

This repo is the beginning of a APS.NET Core web app, which can upload and retrieve a list expenses. Most of its functionality is missing. Your job is to implement it!

Your assignment is to fork this repo to your personal GitHub account and implement the following features:

- Create a controller endpoint to receive an incoming expense (expense should contain an original file (byte array), amount, currency, issue date and a creditor ID (for simplicity we can assume that this ID will be just a Guid)).
- Create a persistance mechanism to store this data (for simplicity and portability we recommend using sqlite here). It is up to you to choose your ORM and decide how to store file bytes.
- Supported currencies will be USD and EUR, when persisting the data we want to persist the original currency value and a normalized one (value converted to USD at the time of submission).
    - We recommend implementing a currency conversion service using a 3rd party RESTful service like fixer.io (they have a free tier, but note that they are rate limiting requests so you might also need a dummy implementation for your testing).
- Create an endpoint to list all expenses
    - **Bonus task:** implement a way to filter expenses by currency or creditor ID
- Create an endpoint to get an expense by ID
- Create an endpoint to delete an expense by ID
- Make sure that your code is covered with unit tests.
- **Bonus task:** create a simple cookie based authentication (credentials can be hard coded)

When you're done, submit a PR (containing one or more commits) targeting this repo's master branch.

## Time limit

From the time you receive access to this repo, you have 4 hours to complete the assignment and submit your PR.

You do not have to use all 4 hours. We value quality over speed, so make sure to do a good job instead of rushing.

If you exceed the 4 hours, no worries, just submit what you have. But, please, submit something within the time limit.

If you encounter an unexpected interruption and must leave the assignment unfinished, please reach out to us, and we'll accommodate.

**Note:** At Roger, we don't have deadlines like this, which could potentially mean rushed launches with sub-optimal user experiences. This is an assignment, and we want to set clear a expectation of how much of your time we expect.

## Tips and pointers

- Make use of proper DI that ASP.NET Core comes with out of the box, it will help with unit testing your code
- Create proper abstractions and write tests to meet specifications of the assignment and develop against that instead of relying on manual testing
- Divide your code into logical components and implement them one by one
- Bonus points for using proper configuration management
- Bonus tasks are nice to have but not mandatory
- We value clear, consistent and well-formatted code.
- Make sure your app has not warnings or compilation errors before submitting.
- We promise to give you constructive feedback on your work.
- If anything is unclear, please reach out to us asap.
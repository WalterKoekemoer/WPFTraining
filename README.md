# WPFTraining

Create a single window application with two views.

The first view should provide the user with a form where they can provide the following personal details:
- Name
- Surname
- Cellphone number
- Email address
Upon committing these details, they shall be stored in a local SQLite database.

The second window shall be password-protected and allow the user to browse through all details previously entered.
The details shall be searchable by name and surname and be sortable by any of the details provided.
The user shall also be able to select multiple items from the list of details and export them in CSV format for sharing.

EFCore shall be used as an ORM.
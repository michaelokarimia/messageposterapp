## Message Poster App

Console application which can store and retrieve users messages that are entered into standard input.

The application accepts and stores users messages from standard input in the following format:

`>username: Message`

for example:

`>Jane: Hi and welcome to this chat room`

`>Billy: We hope you enjoy it here`

`>Billy: There are useful tutorials available on our wiki to help you get started`


User messages (along with how old the message is), can be retrieved by entering in the user's name into console standard input.

`> Billy`

`Billy: We hope you enjoy it here (5 minutes ago)`

`Billy: There are useful tutorials available on our wiki to help you get started (4 minutes ago)`

Should the user not exist, return the message `User name not found`

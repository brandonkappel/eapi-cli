# Effortlless API Project CLI

This seed will create a fully functional, secure implementation with access to your
EffortlessAPI endpoint for easy automation on the scripting platform of your choice.

## Installation
Creating a CLI for your project involves the following steps:
1. Clone this repository to a folder called `/eapi-cli`
6. Install the NPM package locally to test `> npm install . -g`
7. Test the package: `> eapi help`
   
See below for further help/instructions.

## Potential Errors
If you run into the following errors while installing the NPM package follow these steps.
https://stackoverflow.com/questions/52376567/how-to-resolve-unable-to-find-package-nuget-error
https://stackoverflow.com/questions/1421862/metadata-file-dll-could-not-be-found

## Usage
The following behaviors are common across all CLI's.  The specifics beyond what
is described here will depend on the specific EffortlessAPI project being
managed.

### Authentication
Any CLI will include simple commands for authenticating with any of the methods supported

> eapi -authenticate you@domain.com -demoPassword Password123
> eapi -authenticate you@domain.com -sha256HashedPassword xyzq23k321zyx
> eapi -authenticate -withGoogle
> eapi -authenticate -withFacebook
> eapi -authenticate -withTwitter

### -as Role
By default, the first commands issued will be assumed to come from `-as Guest`, however, Any command can be updated to also include `-as Employee`, or `-as AnyRole` which will override the default.

It will also "remember" that request, and any subsequent requests which do not
specify the `-as ExplicitRole` will be invoked using the previous role.

### -help or help
Any any time you can request help as follows:
> eapi -help GetInv
> eapi -help
> eapi help
> eapi help -as Employee
> eapi help -as Guest

This will list any commands which the given user can access.

> eapi help GetEffortlessAPIProjects -as Developer

Because this matches a specific method that Developer can reference, the
help will provide a detailed description of the method/payload, response, etc.

### Options
   -amqps                      AMQPS Connection String
   -appId                      application.id of the airtable project to add.
   -authenticate               Authenticate as a user
      > eapi -authenticate (yourEmail) -demopassword (yourPassword) -as Developer
   -betaRepo                   Use the beta repository for this seed?
   -bodyData                   Raw data provided
   -bodyFile                   Path to file to use
   -cloneEAPISeed              Clone the given seed
      > eapi -cloneEAPISeed (seedName) (folder) (project)
   -createAirtableProject      Create an EffortlessAPI for Airtable Project
                               based on an airtable.json application.
   -demoPassword               the user's password
   -help                       Get help on a given topic
   -invoke                     Invoke a method
   -listSeeds                  List all available seeds
   -maxPages                   How many pages of results should be returned
   -name                       Name for the new project.
   -output                     Output file name
   -reloadCache                Reload cache of project types, plans and such
   -repoUrl                    Override the default URL
                               specified bythe seed repository
   -runas, -as                 Who to run as
   -where                      Limit the where clause
   -whoami                     Check who you are currently operating as


```Help for Developer.

Available Actions Matching: getcustomers
 - GetEffortllessAPIProjects

* * * * * * * * * * * * * * * * * * * * * * * * * * *
* *  EffortlessAPIProject                           *
* *     - A project on the EffortlessAPI Platform.  *
* * * * * * * * * * * * * * * * * * * * * * * * * * *

CRUD      - EffortlessAPIProjectId
CRUD      - Name
CRUD      - Notes
CRUD      - Attachments
...
CRUD      - OwnerEmailAddress
```

There will also be a detailed Html description of how to interact with the
CLI as well at `/cli.html`.


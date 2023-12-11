# Blackbird.io Lokalise

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->  

Lokalise is a continuous localization and translation management platform. This Lokalise application primarily centers around project, key and task management.

## Connecting

1. Navigate to apps and search for Lokalise. If you cannot find Lokalise then click _Add App_ in the top right corner, select Lokalise and add the app to your Blackbird environment.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My client'.
4. Go to your Lokalise profile `https://app.lokalise.com/profile`
5. Select _API tokens_ section
6. Click _Generate new token_, select token type. After that click _Generate_
7. Copy generated token and paste it to the appropriate field in Blackbird
8. Click _Connect_.
9. Confirm that the connection has appeared and the status is _Connected_.

## Actions

### Comments

- **Add comments** adds comments to a specific `Key`.

### Files

- **List all project files** returns a list of file from the specific `Project`. You can filter them by name.
- **Download all project files as ZIP** returns a ZIP file with all project files.
- **Download project source/translated files"** returns a list of project files.
- **Download XLIFF file** downloads file from task by language.
- **Download XLIFF files from task** returns all task XLIFF files.
- **Download all XLIFF files from project** returns all project XLIFF files.
- **Upload/Delete file for project**

### Keys

- **List all project keys** returns a list of keys for the specified project.
- **Get/Create/Delete key**

### Languages

- **List all system languages** returns a list of languages supported by Lokalise.
- **List all project languages** returns a list of languages added to the `Project`.
- **Build language** returns language object that can be used during `Task` creation. This way you can build multiple languages with unique assignees.
- **Add/Delete delete project language**

### Projects

- **Empty project** deletes all `Keys` and `Translations` from the specified project.
- **List projects by date** returns a list of projects filtered by creation date interval.
- **List/Get/Create/Update/Delete project(s)**

### Segments

- **List/Get/Update segment(s)**

### Tasks

- **Create task from the built languages** creates a new task with languages from `Build language` action results. Note: ordinary `Create` task action assigns all specified users/groups to all of the languages. If you need languages to have unique users/groups, please use this action.
- **List/Create/Get/Update/Delete task(s)**

### Translations

- **Update translation** updates specific translation

## Events

-   **On key modified for assignee** triggers when project key is added/modified or a new task is created.
-   **On project imported**
-   **On project exported**
-   **On project deleted**
-   **On project snapshot**
-   **On project branch added**
-   **On project branch deleted**
-   **On project branch merged**
-   **On project languages added**
-   **On project language removed**
-   **On project language settings changed**
-   **On project key added**
-   **On project keys added**
-   **On project key modified**
-   **On project keys deleted**
-   **On project key comment added**
-   **On project translation updated**
-   **On project translations updated**
-   **On project translation proofread**
-   **On project contributor added**
-   **On project contributor deleted**
-   **On team order created**
-   **On team order deleted**
-   **On team order completed**
-   **On project task initial TM leverage calculated**
-   **On project task created**
-   **On project task closed**
-   **On project task deleted**
-   **On project task language closed**

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->

# Keep REST API - Similar to Google Keep

#This is in continuation to your previous assignment

**Objective:** Create ASP.NET Core Web API which should be able to drive some of the features of Google Keep Application.

The intent of the application is to use **Entity Framework Core** and **ASP.NET Core Web API**

## Google Keep Specs
- A Note can have potential things:
  - Must have a **title**
  - Can have **plain text**
  - Can have **checklist**, basically a list of items
  - Can have a set of **labels**
  
- Should be able to **create** notes
- Should be able to **retrieve** all/individual notes
- Should be able to **delete** a Note
- Should be able to **Add/Remove/Edit** label for a note
- Should be able to **Add/Remove/Edit** checklist for a note
- Should be able to **Search** note/notes by label
- Should be able to **Search** note/notes by title

## You API should expose below mentioned URI

- GET  /notes - To retreive all notes
- GET /notes/{id} - to retreive a note by Id
- POST /notes - To create a new Note
- DELETE /notes/{id} - To delete an existing note

- POST /notes/{id}/labels - To add a new label for existing note
- DELETE /notes/{id}/labels/{labelid} - To delete a label from existing note
- PUT /notes/{id}/labels/{labelid} - To update an existing label of existing note

- POST /notes/{id}/checklist - To add a new checklist item for existing note
- DELETE /notes/{id}/checklist/{itemId} - To delete a checklist item from existing note
- PUT /notes/{id}/checklist/{itemId} - To update an existing checklist item of existing note

- GET  /notes/getnotesbylabel/{lblText} - To retreive all notes by label
- GET  /notes/getnotesbytitle/{title} - To retreive all notes by title

## Instructions
- Boilerplate for the assignment is located here:
  https://gitlab-cts.stackroute.in/aspnetcore/aspnetcore_assignment_step3_boilerplate.git

#### To use this as a boilerplate for your new project, you can follow these steps

1. Clone the base boilerplate in the folder **aspnetcore_assignment-solution-step3** of your local machine
     
    `git clone https://gitlab-cts.stackroute.in/aspnetcore/aspnetcore_assignment_step3_boilerplate.git` 

2. Navigate to aspnetcore_assignment-solution-step3 folder

    `cd aspnetcore_assignment-solution-step3`

3. Remove its remote or original reference

     `git remote rm origin`

4. Create a new repo in gitlab named `aspnetcore_assignment-solution-step3` as private repo

5. Add your new repository reference as remote

     `git remote add origin https://gitlab-cts.stackroute.in/{{yourusername}}/aspnetcore_assignment-solution-step3.git`

     **Note: {{yourusername}} should be replaced by your username from gitlab**

5. Check the status of your repo 
     
     `git status`

6. Use the following command to update the index using the current content found in the working tree, to prepare the content staged for the next commit.

     `git add .`
 
7. Commit and Push the project to git

     `git commit -a -m "Initial commit | or place your comments according to your need"`

     `git push -u origin master`

8. Check on the git repo online, if the files have been pushed

### Important instructions for Participants
> - We expect you to write the assignment on your own by following the guidelines, learning plan, and the practice exercises
> - The code must not be plagiarized, the mentors will randomly pick the submissions and may ask you to explain the solution
> - The code must be properly indented, code structure maintained as per the boilerplate and properly commented
> - Follow the problem statement shared with you
### breaking change
#### limitations
1. breaking changes can only be applied on top of the highest major/minor version number combination
#### process
1. find the highest {major}.{minor} version branch
2. git checkout {major}.{minor}
3. git checkout -b {major + 1}.0
4. develop change

### non-breaking API change
#### limitations
1. non-breaking API changes can only be applied to the highest minor version within each major version
#### process
1. find the highest {minor} version branch within a {major} version that can take the API change
2. git checkout {major}.{minor}
3. git checkout -b {major}.{minor + 1}
4. develop change
5. for each other major version, apply the change on top of the highest minor version branch within that major version if that major/minor combination can take the 
   API change
   
### non-breaking non-API change
#### limitations
1. non-breaking non-API changes can only be applied to the highest revision version within each major/minor version combination
#### process
1. find a {major}.{minor} version branch that can take the change
2. git checkout {major}.{minor}
3. develop change
4. for each other major/minor version combination, apply the change to that version branch if the branch can take the change
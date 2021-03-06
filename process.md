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


### NOTE
1. we use branches and not tags; these release branches are under active development, so it makes sense to track them as branches. if we want to add a tag to the specific revision version commits when we do the release process for tracking, that is fine, but unrelated
2. we do not have to release every version branch that gets generated
3. just because we have been able to take a change in an older version branch due to convenience does not mean that we are committing to actively maintaining that version
4. if releases are automated, there is low overhead for following this process, and it gives customers fixes more often
5. we can release breaking changes more often because we will be able to easily take fixes from lower versions into higher versions (and vice versa) without the additional maintenance cost

```c#
void ApplyNonbreakingApiChange(int major, int minor)
{
  for (int i = major + 1; true; ++i)
  {
    git checkout {i}.0
    if (%errorlevel% != 0)
    {
      // this major version doesn't exist, we are done
      break;
    }
  
    int j;
    for (j = 1; true; ++j)
    {
      git checkout {i}.{j}
      if (%errorlevel% != 0)
      {
        // we found the highest minor version within this major version
        break;
      }
    }
    
    git checkout -b {i}.{j+1}
    git cherry-pick {major}.{minor + 1}
    if (%errorlevel != 0)
    {
      git cherry-pick --abort
      
      // this major version cannot take the new API, higher major versions won't be able to either
      break;
    }
  }
}
```

Hi there!
Don't push to main branch anything!

One time:
git init
git remote add origin git@github.com:doc3n3/TTGames_Alicher.git
git pull origin main

Every time:
git switch main
git branch ${branch_name}
git switch ${branch_name}

Some work...

Push:
git status
git add .
git commit -m "${branch_name} ready"
git push origin ${branch_name}

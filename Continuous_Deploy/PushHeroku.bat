@echo off
echo
call CreateDockerFile.bat
set/p App= ¿app name?
docker build -t %App% ./
docker tag %App% registry.heroku.com/%App%
docker push registry.heroku.com/%App%
heroku container:push web -a %App%
heroku container:release web -a %App% 
heroku container:release web
exit
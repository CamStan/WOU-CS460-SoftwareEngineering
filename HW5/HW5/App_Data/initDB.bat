@ECHO off
SET DBFILENAME=460_HW5.mdf
SET DBLOGFILENAME=460_HW5_log.ldf
SET INITSCRIPT=initDB.sql

REM If db and db files already exist, detach them first in Visual Studio Server Explorer

REM If db already exists and is attached, detach it first
::sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "EXEC sp_detach_db [%CD%\%DBFILENAME%],[true]"
IF EXIST %DBFILENAME% del %DBFILENAME%
IF EXIST %DBLOGFILENAME% del %DBLOGFILENAME%
REM Run script to create and initialize database, both files and db in master
sqlcmd -S "(localdb)\MSSQLLocalDB" -v dbdir="%CD%" -i %INITSCRIPT% -b

REM Uses this technique to inject full path: stackoverflow.com/questions/139245/relative-path-in-t-sql (mateuscb)
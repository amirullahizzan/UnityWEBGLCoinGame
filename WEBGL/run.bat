@echo off
title Unity WebGL Local Server

REM === Change to the folder this BAT file is in ===
cd /d "%~dp0"

REM === Start Python server in a new background window ===
start "" cmd /c "python -m http.server 8000"

REM === Wait briefly to let the server start ===
timeout /t 2 /nobreak > nul

REM === Open the index.html in the browser ===
start "" http://localhost:8000/index.html

REM === Done ===
echo Server started and browser opened.
pause

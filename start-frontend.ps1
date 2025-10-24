# Start Frontend App
Write-Host "Starting Frontend..." -ForegroundColor Green
$env:Path += ";C:\Program Files\nodejs"
Set-Location "Frontend"
npm run dev

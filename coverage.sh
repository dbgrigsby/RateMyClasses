dotnet restore
dotnet build

cd tools
dotnet minicover uninstrument --workdir ../ # Reset from failed run

# Instrument assemblies inside 'test' folder to detect hits for source files inside 'src' folder
dotnet minicover instrument --workdir ../ --assemblies RateMyClassesTester/**/bin/**/*.dll --sources RateMyClasses/Controllers/*.cs --sources RateMyClasses/Models/Course.cs --sources RateMyClasses/Models/Review.cs --sources RateMyClasses/Models/SISImporter.cs --sources RateMyClasses/Models/Student.cs 

# Reset hits count in case minicover was run for this project
dotnet minicover reset

cd ..

for project in RateMyClassesTester/*.csproj; do dotnet test --no-build $project; done

#       Selenium coverage -- not working
# add --assemblies RateMyClasses/**/*.dll to the instrument command
# dotnet run --project RateMyClasses/RateMyClasses.csproj --no-build --no-restore
# read -p "Please run the selenium tests or manual tests, then hit enter."

cd tools

# Uninstrument assemblies, it's important if you're going to publish or deploy build outputs
dotnet minicover uninstrument --workdir ../

# Create html reports inside folder coverage-html
dotnet minicover htmlreport --workdir ../ --threshold 80

# Print console report
# This command returns failure if the coverage is lower than the threshold
dotnet minicover report --workdir ../ --threshold 80

cd ..
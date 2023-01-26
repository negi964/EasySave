FROM microsoft/dotnet-framework:4.7.2-sdk 
COPY . /app
WORKDIR /app
RUN cd EasySave && dotnet build
RUN dotnet EasySave.dll
EXPOSE 5000
ENTRYPOINT ["dotnet", "run"]
public class MassConstructor()
{
    public void Main()
    {
        Company[] companies =
        [
new(new Company.Language(){
    CSharp =
    java =
    spring =
    jsp =
    tomcat =
    intelliJ =
    maven =
    docker =
    html =
    unclear =
}, new Company.Engine(){
    unity =
    unreal =
    unclear =
}, new Company.Platform(){
    web =
    vr =
    xr =
    pc =
    phone =
    unclear =
}, new Company.Collaboration(){
    collaborating =
    independent =
}, new Company.Location(){
    workFromHome =
    onSite =
    hybrid =
}, new Company.Level(){
    unclear=
    allWelcome=
    mbo=
    hbo=
    university=
}, new Company.Compensation(), new Company.Rest(){
    goodVibes=
    badVibes=
    portfolio=
    motivation=
}, new Company.Git(){
    gitLab=
    gitHub=
}
        ];


    }

}



public class Company
{
    public Company(Language language, Engine engine, Platform platform, Collaboration collaboration, Location location, Level level, Compensation compensation, Rest rest, Git git)
    {
        Language = language;
        Engine = engine;
        Platform = platform;
        Collaboration = collaboration;
        Location = location;
        Level = level;
        Compensation = compensation;
        Rest = rest;
        Git = git;
    }

    public struct Language
    {
        Language()
        {

        }

        public bool CSharp;
        public bool Java;
        public bool Spring;
        public bool Jsp;
        public bool Tomcat;
        public bool IntelliJ;
        public bool Maven;
        public bool Docker;
        public bool Html;
        public bool Unclear;
    }
    public Language Language;

    public struct Engine
    {
        public bool unity;
        public bool unreal;
        public bool unclear;
    }
    public Engine Engine;

    public struct Platform
    {
        public bool web;
        public bool vr;
        public bool xr;
        public bool pc;
        public bool phone;
        public bool unclear;
    }
    public Platform Platform;

    public struct Collaboration
    {
        public bool collaborating;
        public bool independent;
    }
    public Collaboration Collaboration;

    public struct Location
    {
        public bool workFromHome;
        public bool onSite;
        public bool hybrid;
    }
    public Location Location;

    public struct Level
    {
        public bool unclear;
        public bool allWelcome;
        public bool mbo;
        public bool hbo;
        public bool university;

    }
    public Level Level;

    public struct Compensation
    {
        public int amount;
    }
    public Compensation Compensation;

    public struct Rest
    {
        public bool goodVibes;
        public bool badVibes;
        public bool portfolio;
        public bool motivation;
    }
    public Rest Rest;

    public struct Git
    {
        public bool gitLab;
        public bool gitHub;
    }
    public Git Git;

}


using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Data
{
    class Datastore
    {
        public static ObservableCollection<Unit> AllUnits = GenerateAllUnits();

        public static Student GetStudent()
        {
            Student returnValue = new Student("James Robertson", GetSemesters());
            ObservableCollection<Unit> currentUnits = GetUnits(new string[] { "IFB102", "IFB103", "IFB104", "IFB105" });
            returnValue.CurrentUnits = currentUnits;

            return returnValue;
        }

        public static ObservableCollection<Semester> GetSemesters()
        {
            ObservableCollection<Semester> semesters = new ObservableCollection<Semester>();

            ObservableCollection<Unit> units = GetUnits(new string[] { "IFB102", "IFB103", "IFB104", "IFB105" });
            Semester semester = new Semester(new ObservableCollection<int> {0, 0}, units);
            semesters.Add(semester);

            units = GetUnits(new string[] { "CAB201", "CAB202" });
            semester = new Semester(new ObservableCollection<int> { 1, 0 }, units);
            semesters.Add(semester);

            units = new ObservableCollection<Unit>();
            for(int x = 1; x < 3; x++)
            {
                for(int y = 0; y < 2; y++)
                {
                    semester = new Semester(new ObservableCollection<int> { y, x }, units);
                    semesters.Add(semester);
                }
            }

            return semesters;
        }

        public static ObservableCollection<Minor> GetMinors()
        {
            ObservableCollection<Minor> minors = new ObservableCollection<Minor>();

            ObservableCollection<Unit> units = GetUnits(new string[] {"IAB320", "IAB321", "IAB402", "IAB303", "IAB250"});
            ObservableCollection<string> information = new ObservableCollection<string>();
            information.Add("Business Process Management is a systematic approach to making the workflow of the organization more effective");
            information.Add("You will learn how to discover, analyse, model, improve, automate and monitor various business processes");
            information.Add("Units of this minor will prepare you to conduct an end to end organisational process improvement project, from analysis to redesign");
            information.Add("You will practice how to automate an executable business process using a business process management system and will monitor its progress by using various post-execution techniques");

            minors.Add(new Minor(information, units, "Business process management"));

            units = GetUnits(new string[] {"MXB261", "MXB262", "MXB161", "MXB361", "MXB362"});
            information = new ObservableCollection<string>();
            information.Add("This hands on, real-world based curriculum will give you the opportunity to explore a wide range of areas within IT and gain a deep understanding of your chosen area of specialty, such as software development, networking,  data science, business processes, information management, and social technologies");
            information.Add("The degree is designed to develop creative, innovative problem-solving skills through teaching design thinking and human-centred design");
            minors.Add(new Minor(information, units, "Computational and Simulation Science"));

            units = GetUnits(new string[] {"CAB201", "CAB202", "CAB203", "CAB303"});
            information = new ObservableCollection<string>();
            information.Add("Computer science is the scientific and practical approach to computer-based system design, development and operation");
            information.Add("It deals with areas ranging from the fundamental principles of computation through to tools and techniques for IT system development and evaluation, including identifying and solving systems design issues associated with efficiency, usability and security");
            information.Add("Computer science applications extend into specialised areas including mobile computing, artificial intelligence, robotics, and large-scale information management involving information retrieval and web search engines");
            minors.Add(new Minor(information, units, "Computer Science"));

            units = GetUnits(new string[] {"IAB250", "IAB351", "IAB352", "BSB115", "IAB230", "IAB401", "IAB320"});
            information = new ObservableCollection<string>();
            information.Add("Enterprise systems are large scale application software packages that support business processes and information flows across departments");
            information.Add("This minor develops the knowledge and skills required in supporting Enterprise Systems within the modern organisation");
            information.Add("It develops an understanding of the Enterprise Systems Lifecycle and cloud computing services");
            information.Add("You will learn how to select an appropriate enterprise system for the organisation and how to configure a component of the enterprise system based on user requirements");
            minors.Add(new Minor(information, units, "Enterprise systems"));

            units = GetUnits(new string[] {"CAB320", "EGB339", "MXB103", "CAB201", "CAB420"});
            information = new ObservableCollection<string>();
            information.Add("Robotics and artificial intelligence progressively allow robots to perform boring, repetitive tasks (cleaning, assembly line, environment monitoring and farming) as well as tasks too dangerous for humans, such as mining or fire-fighting");
            information.Add("This minor provides an introduction to the field of robotics and intelligent systems technologies");
            information.Add("You will learn how to design and build simple robotic systems and how to apply advanced algorithms and data structures to solve common problems");
            minors.Add(new Minor(information, units, "Intelligent systems"));

            units = GetUnits(new string[] { "IAB230", "IAB330", "CAB230", "CAB240", "CAB432" });
            information = new ObservableCollection<string>();
            information.Add("The Mobile Application minor develops your knowledge and skills to design, develop and distribute applications or games delivered as a Mobile Application");
            information.Add("You will learn about ubiquitous and pervasive computing, wireless and sensor technologies and applications of Mobile Applications in business and their effects on individuals and enterprises");
            minors.Add(new Minor(information, units, "Mobile applications"));

            units = GetUnits(new string[] { "CAB203", "CAB303", "CAB240", "CAB340", "CAB440", "CAB441" });
            information = new ObservableCollection<string>();
            information.Add("This minor develops your knowledge and skills in creating contemporary electronic communications infrastructure, concentrating on fundamental networking technologies and information security principles");
            information.Add("Information systems are vital for all sectors of the economy but are also vulnerable");
            information.Add("IT professionals are expected to have an understanding of the vulnerabilities and threats that computer systems under their protection may be exposed to");
            information.Add("You will learn how to operate, administer and manage computer networks and design communications networks for particular application domainsYou will learn how to operate, administer and manage computer networks and design communications networks for particular application domains");
            information.Add("You will also design security technologies for preserving and protecting data confidentiality, integrity, accessibility and privacy as part of this minor");
            minors.Add(new Minor(information, units, "Networks and Security"));

            return minors;
        }

        public static ObservableCollection<Major> GetMajors()
        {
            ObservableCollection<Major> majors = new ObservableCollection<Major>();

            ObservableCollection<Unit> units = GetUnits(new string[] { "IFB102", "IFB103", "IFB104", "IFB105", "CAB201", "CAB202", "CAB203", "CAB302", "CAB303", "IFB295", "CAB301", "IFB398", "CAB402", "CAB420", "IFB399", "CAB401", "CAB403" });
            ObservableCollection<string> information = new ObservableCollection<string>();
            information.Add("72 credit points (6 units) of information technology core units, which includes 24 credit points (2 units) of option unit* selected from an approved ObservableCollection");
            information.Add("120 credit points (10 units) of major core units");
            information.Add("96 credit points of complementary studies comprising of either a second major (8 unit set); or two minors (4 unit set each); or one minor (4 unit set) plus 4 elective units");
            information.Add("Computer science is the scientific and practical approach to computer-based system design, development and operation");
            information.Add("It deals with areas ranging from the fundamental principles of computation through to tools and techniques for IT system development and evaluation, including identifying and solving systems design issues associated with efficiency, usability and security");
            information.Add("Computer science applications extend into specialised areas including mobile computing, artificial intelligence, robotics, and large-scale information management involving information retrieval and web search engines");
            majors.Add(new Major(information, units, "Computer Science"));

            units = GetUnits(new string[] { "IFB102", "IFB103", "IFB104", "IFB105", "IAB201", "IAB207", "IAB203", "IAB204", "IFB295", "IAB305", "IAB206", "IAB320", "IAB303", "IFB398", "IAB260", "IAB402", "IFB399", "IAB401" });
            information = new ObservableCollection<string>();
            information.Add("72 credit points (6 units) of information technology core units, which includes 24 credit points (2 units) of option unit* selected from an approved ObservableCollection");
            information.Add("120 credit points (10 units) of major core units");
            information.Add("96 credit points of complementary studies comprising of either a second major (8 unit set); or two minors (4 unit set each); or one minor (4 unit set) plus 4 elective units");
            information.Add("Information systems focuses on identifying organisational requirements for applications and acquiring effective systems solutions, whether custom designed and built or selected and implemented, to meet the requirements");
            information.Add("Skills involve the design, development and maintenance of large database applications for business, as well as the identification, purchase and implementation of packaged software addressing business problems");
            information.Add("It does not require in-depth knowledge of computer programming but rather in-depth specialised knowledge of databases and software used in business");
            majors.Add(new Major(information, units, "Information Systems"));

            units = GetUnits(new string[] {"CAB401", "CAB201", "MXB100", "MXB103", "MXB161", "MXB261", "MXB262", "MXB361", "MXB362"});
            information = new ObservableCollection<string>();
            information.Add("This hands on, real-world based curriculum will give you the opportunity to explore a wide range of areas within IT and gain a deep understanding of your chosen area of specialty, such as software development, networking,  data science, business processes, information management, and social technologies");
            information.Add("The degree is designed to develop creative, innovative problem-solving skills through teaching design thinking and human-centred design");
            majors.Add(new Major(information, units, "Computational and Simulation Science"));

            units = GetUnits(new string[] {"MXB101", "MXB107", "MZB151", "CAB201", "CAB220", "CAB420", "BSB123", "CAB330", "IAB303", "MXB161", "MXB261", "MXB262", "MXB361"});
            information = new ObservableCollection<string>();
            information.Add("Data Science provides the necessary skills to be a data scientist including statistical methods and data visualisation, computational tools for and data management techniques for large datasets, and high-performance computing resources and techniques");
            information.Add("This unique skill-set in statistics and computing will allow you to cope with sophisticated models applied to complex and/or large datasets");
            majors.Add(new Major(information, units, "Data Science"));


            return majors;
        }

        public static ObservableCollection<Unit> GetUnits(string[] unitCodes)
        {
            ObservableCollection<Unit> returnObservableCollection = new ObservableCollection<Unit>();
            foreach(string unitCode in unitCodes)
            {
                Unit unit = GetUnit(unitCode);
                if(unit.Code == unitCode)
                {
                    returnObservableCollection.Add(unit);
                }
            }

            return returnObservableCollection;
        }

        public static Unit GetUnit(string unitCode)
        {
            foreach(Unit unit in AllUnits)
            {
                if(unit.Code == unitCode)
                {
                    return unit;
                }
            }

            return new Unit();
        }

        public static ObservableCollection<Unit> GenerateAllUnits()
        {
            ObservableCollection<Unit> units = new ObservableCollection<Unit>();

            ObservableCollection<string> information = new ObservableCollection<string>();
            ObservableCollection<Announcement> announcements = new ObservableCollection<Announcement>();
            ObservableCollection<Assesment> assesment = new ObservableCollection<Assesment>();
            ObservableCollection<Resources> resources = new ObservableCollection<Resources>();
            ObservableCollection<String> resourcesFiles = new ObservableCollection<String>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This is an introductory computer science unit concerning computer systems, in particular how modern computer systems work, how they are structured, and how they operate");
            information.Add("Computer systems are ubiquitous and yet they are unlike any other man-made product or system; they appear magical and are notoriously difficult to work with and manage in projects");
            information.Add("This unit’s goal is to demystify computer systems so students can appreciate, understand and utilise computer systems in their subsequent learning, and effectively participate in the IT industry");
            information.Add("Students will study computers, networks, operating systems and the Web");
            information.Add("Raspberry Pi computers will be used throughout the unit and at the end students will build their own small computer system using a Raspberry Pi");
            announcements.Add(new Announcement("IFB102", "Raspberry Pi", "Good morning, students should now be aware of the requirement for a raspberry pi to complete this unit. Please either buy or borrow one ASAP, kits are available in the QUT bookstore", new DateTime(2020, 03, 01, 08, 14, 22), "Michael Adams"));
            announcements.Add(new Announcement("IFB102", "Welcome students!", "Hello students, I would like to welcome you all to IFB102. Please make sure you attend your week 1 tutorial for information regarding what you will need for the semester", new DateTime(2020, 02, 24, 16, 30, 0), "Michael Adams"));
            assesment.Add(new Assesment("IFB102", "Technology Report 1", 25, new DateTime(2020, 03, 01, 12, 0, 0).ToShortDateString(), new DateTime(2020, 04, 12, 12, 0, 0).ToShortDateString(), false, "TBC", "0", "true"));
            assesment.Add(new Assesment("IFB102", "Technology Report 2", 25, new DateTime(2020, 04, 01, 12, 0, 0).ToShortDateString(), new DateTime(2020, 05, 12, 12, 0, 0).ToShortDateString(), false, "TBC", "0", "true"));
            assesment.Add(new Assesment("IFB102", "Raspberry Pi Project", 50, "TBC", "TBC", false, "TBC", "0", "false"));
            resourcesFiles.Add("Week1_lecture_slides.pdf");
            resourcesFiles.Add("Week1_unit_overview.pdf");
            resources.Add(new Resources("Week 1", resourcesFiles, "Week 1 Lecture"));
            resourcesFiles = new ObservableCollection<string>();
            resourcesFiles.Add("Week2_lecture_slides.pdf");
            resourcesFiles.Add("Week2_tutorial_slides.pdf");
            resources.Add(new Resources("Week 2", resourcesFiles, "Week 2 Lecture"));
            Unit IFB102 = new Unit("IFB102", "Introduction to Computer Systems", information, "#80EE8B", announcements, assesment, resources);
            units.Add(IFB102);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Developing an innovative, practical and cost-effective IT solution that is user-focused is a complex task for IT experts");
            information.Add("It requires a systematic process that includes: 1) identifying and clarifying a business problem that an IT system can help to resolve; 2) collecting and interpreting requirements; 3) decomposing the system into its components; and, 4) prototyping techniques to ensure that all the components of the system satisfy the requirements");
            information.Add("This unit presents students with authentic industry challenges in which you apply your IT knowledge, fundamental analysis and design techniques");
            information.Add("It exposes you to design contexts, theories, processes, principles and methods that IT experts use, either individually or in a group, to analyse and design an IT system");
            information.Add("The unit builds your skills towards any career related to operational analysis and design of a specific business scope, including Business Systems Analyst, Solution Architect, and Project Manager");
            assesment.Add(new Assesment("IFB102", "Application Design - Assignment 1", 40, new DateTime(2020, 02, 20, 12, 35, 10).ToShortDateString(), new DateTime(2020, 03, 14, 12, 0, 0).ToShortDateString(), true, new DateTime(2020, 03, 19, 12, 0, 0).ToShortDateString(), "28.5/30", "true"));
            assesment.Add(new Assesment("IFB102", "Application Prototypes - Assignment 2", 40, new DateTime(2020, 03, 01, 12, 0, 0).ToShortDateString(), new DateTime(2020, 04, 12, 12, 0, 0).ToShortDateString(), false, "TBC", "0", "true"));
            assesment.Add(new Assesment("IFB102", "Final Exam", 20, "TBC", "TBC", false, "TBC", "0", "false"));
            Unit IFB103 = new Unit("IFB103", "IT Systems Design", information, "#F3B15B", announcements, assesment, resources);
            units.Add(IFB103);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This is an introductory unit on database addressing the core concepts, requirements and practices of databases");
            information.Add("It introduces conceptual data modeling to address a key area of concern of modeling structured data to build a comprehensive understanding of the data aspect of a problem");
            information.Add("You will learn how to transform such data model into a relational database design as well as how to effectively retrieve data through SQL queries");
            information.Add("Normalization, database security/administration, other special topics and ethical aspects related to information systems are also covered");
            information.Add("IAB207 Rapid Web App Development, IAB303 Data Analytics for Business Insights and the Capstone units IFB398 Capstone 1 and IFB399 Capstone 2 build on this unit for data storage/retrieval and business insights");
            information.Add("IAB206 Modern Data Management extends this unit earning to unstructured data such as graphs and documents which are also gaining popularity in the real world");
            announcements.Add(new Announcement("IFB105", "IFB105 - Week 1", "Welcome to week 1 of IFB105. This unit will give you an in depth introduction to databases, different types of modelling techniques and SQL. Tutorials will begin in week 2, please make sure you have watched the week 1 lecture prior to attending.", new DateTime(2020, 02, 22, 11, 34, 43), "Robert Andrews"));
            Unit IFB105 = new Unit("IFB105", "Database Management", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(IFB105);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit provides a hands-on introduction to computer programming for students with no prior coding experience at all");
            information.Add("It introduces the basic principles of programming in a typical imperative language, including expressions, assignment, functions, choice and iteration");
            information.Add("It then shows how to use Application Programming Interfaces to complete common Information Technology tasks such as querying databases, creating user interfaces, and searching for patterns in large datasets");
            information.Add("The emphasis is on developing skills through practice, so the unit includes numerous coding exercises and assignments, using a simple scripting language and code development environment");
            information.Add("The unit establishes a foundation for later subjects that teach large-scale software development using industrial-strength programming languages");
            announcements.Add(new Announcement("IFB104", "Quiz 1 Grades", "The grades for quiz 1 can now be viewed. Results should now be available to students in the future upon completion of the quiz.", new DateTime(2020, 03, 04, 14, 56, 21), "Alistair Barros"));
            announcements.Add(new Announcement("IFB104", "Week 1 Resources", "Good morning, The lecture and tutorial materials from week 1 have now been made accesable on blackboard.", new DateTime(2020, 03, 02, 13, 14, 22), "Alistair Barros"));
            announcements.Add(new Announcement("IFB104", "Welcome to IFB104", "Hello students, welcome to IFB104. This is an introductory unit to coding, we will be using python throughout the semester. The assesment structure will include weekly quizes, two assignments and an exam. Tutorials will start in week 2.", new DateTime(2020, 02, 25, 13, 14, 22), "Alistair Barros"));
            Unit IFB104 = new Unit("IFB104", "Building IT Systems", information, "#EFE379", announcements, assesment, resources);
            units.Add(IFB104);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit builds on the gentle introduction to programming provided in IFB104 or MZB126");
            information.Add("In those units students learn how algorithms are constructed by combining the logical structures of Sequence, Selection and Iteration");
            information.Add("Students also learn how functions can be used to abstract and reuse sections of code");
            information.Add("These concepts are reinforced in this unit and extended with additional applications of abstraction necessary to combat complexity when building larger systems");
            information.Add("Object-oriented principles are introduced where the program is structured around classes of objects that are identified from the real-world providing a high-level architecture that is better able to stand the test of time as requirements evolve throughout the lifetime of the system");
            information.Add("This unit provides the foundation for the other more advanced and specialized programming units");
            Unit CAB201 = new Unit("CAB201", "Programming Principles", information, "#E1AAEC", announcements, assesment, resources);
            units.Add(CAB201);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces you to the components inside a computer and how these components work together");
            information.Add("The design and development of modern digital electronic systems requires a knowledge of the hardware and software to program the system");
            information.Add("This unit identifies design requirements and lets you develop embedded microcontroller-based system solutions");
            information.Add("Practical laboratory exercises progressively expose features of a typical microprocessor; and explain how an embedded computer can interact with its environment");
            information.Add("This provides a valuable foundation for further studies in areas such as robotics and networking");
            Unit CAB202 = new Unit("CAB202", "Microprocessors and Digital Systems", information, "#AAECDE", announcements, assesment, resources);
            units.Add(CAB202);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("In trying to solve complex problems, a powerful approach is transform the problem into a simpler model by abstracting away some of the less important details");
            information.Add("Once in this more abstract form, powerful mathematical techniques (developed over centuries) can be brought to bear");
            information.Add("For computing related problems, the most relevant mathematical concepts and techniques come from the field of discrete mathematics, and include arithmetic, logic, set theory, graph theory and functions");
            information.Add("This unit demonstrates how these mathematical concepts and techniques can be used to model and solve many real-world problems");
            information.Add("The unit also supports subsequent units: CAB301 where algorithms involving graphs are introduced and CAB402 where the mathematical notion of a function provides the basis for alternative programming paradigms");
            Unit CAB203 = new Unit("CAB203", "Discrete Structures", information, "#CD9864", announcements, assesment, resources);
            units.Add(CAB203);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit teaches you how to work effectively in a team to develop large-scale software systems. It includes principles of teamwork, modern software development methodologies and tools that are needed when working in a team on a large project");
            Unit CAB302 = new Unit("CAB302", "Software Development", information, "#BDD647", announcements, assesment, resources);
            units.Add(CAB302);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Building on your digital systems knowledge, you will be introduced to practical and theoretical knowledge on a wide range of modern networking topics to be able to design, implement and maintain network-based applications");
            information.Add("You will participate in practical networking exercises to provide hands-on experience with network-based computing");
            Unit CAB303 = new Unit("CAB303", "Networks", information, "#80EE8B", announcements, assesment, resources);
            units.Add(CAB303);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("In your information technology career, you will participate in and then lead project teams that are expected to deliver real benefits to stakeholders");
            information.Add("This unit builds on your previous studies of earlier units to define a high-level solution by using a range of approaches of project management methodologies and frameworks");
            information.Add("You will enhance your learning of these approaches (Agile, PRINCE2 etc.) by practicing it collaboratively with other students");
            information.Add("To be successful in a complex environment, you need to employ appropriate project management strategies, tools and techniques for a given context");
            information.Add("This unit provides you with the necessary knowledge and skills to enable you to effectively manage your project in the IFB398 Capstone Project (Phase 1) and IFB399 Capstone Project (Phase 2) and to be prepared for a project environment in industry");
            Unit IFB295 = new Unit("IFB295", "IT Project Management", information, "#F3B15B", announcements, assesment, resources);
            units.Add(IFB295);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit teaches you the fundamental principles used to assess the efficiency of software algorithms, allowing you to distinguish solutions that can process large amounts of data or perform complex calculations effectively from those that run unacceptably slowly or not at all");
            information.Add("In this unit you will examine a range of different algorithm types, review the principles used to predict their efficiency and perform empirical measurements of specific algorithms to confirm the theoretical predictions");
            Unit CAB301 = new Unit("CAB301", "Algorithms and Complexity", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(CAB301);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit gives you the opportunity, under close guidance appropriate to the project, to apply and extend the knowledge and skills gained in your course to date to a substantial IT project");
            information.Add("You will have the opportunity to gain knowledge and skills required for careful planning, scope control and task management to ensure the success of a industry-oriented project");
            information.Add("Working in a team, you will undertake critical tasks required in the early stages of a project, such as: initial concept development and feasibility analysis, requirements gathering and analysis, design and project planning");
            information.Add("These activities will culminate in the delivery of an initial version of the project deliverable (e.g., software prototype, design document, literature review, environmental scan, research plan, etc.) to stakeholders as a proposal for further development in the unit Capstone Project (Phase 2)");
            Unit IFB398 = new Unit("IFB398", "Capstone Project (Phase 1)", information, "#EFE379", announcements, assesment, resources);
            units.Add(IFB398);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This advanced unit exposes you to special-purpose programming languages that operate under different paradigms than the conventional 'imperative' languages you have used in the course so far");
            information.Add("This unit will expose you to new ways of thinking about and expressing software solutions, exploring advanced programming language constructs, principles for the sound design of new languages and how they evolve");
            information.Add("The unit provides both a deep theoretical foundation for programming languages by abstracting them to basic mathematical forms as well as showcasing practical application of those advanced principles for software development in the real world");
            Unit CAB402 = new Unit("CAB402", "Programming Paradigms", information, "#E1AAEC", announcements, assesment, resources);
            units.Add(CAB402);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Machine learning is the science of getting computers to act without being explicitly programmed");
            information.Add("This unit provides you with a broad introduction to machine learning and its statistical foundations");
            information.Add("Topics include: definition of machine learning tasks; classification principles; dimensionality reduction/subspace methods; support vector machines, graphical models and deep learning");
            information.Add("Application examples are taken from areas such as computer vision, finance, market prediction and information retrieval");
            Unit CAB420 = new Unit("CAB420", "Machine Learning", information, "#AAECDE", announcements, assesment, resources);
            units.Add(CAB420);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Building upon the unit IFB398 Capstone Project (Phase 1), this unit gives you the opportunity to apply, under appropriate guidance, the knowledge and skills gained in your course to date to execute the completion of a planned project");
            information.Add("In this unit you will apply your disciplinary and professional knowledge and skills to refine and extend the existing deliverable");
            information.Add("You will use appropriate quality assurance techniques to ensure you are meeting your stakeholders' needs");
            information.Add("You are expected to work professionally in a team to deliver a high quality outcome to project stakeholders");
            information.Add("The final product is to be delivered as a professional package that can be used directly by stakeholders and, where appropriate, published for access by the broader community");
            Unit IFB399 = new Unit("IFB399", "Capstone Project (Phase 2)", information, "#CD9864", announcements, assesment, resources);
            units.Add(IFB399);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Building on your skills in 'sequential' programming, this unit teaches you the tools and techniques needed to exploit multi-processor computer systems to achieve dramatic performance improvements for computationally intensive problems");
            information.Add("This unit gives you both an understanding of why future computer hardware will be increasingly parallel, the challenges this poses for software development as well as a set of practical skills in creating high-performance programs using today's best tools and techniques");
            Unit CAB401 = new Unit("CAB401", "High Performance and Parallel Computing", information, "#BDD647", announcements, assesment, resources);
            units.Add(CAB401);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit uses operating system concepts to teach the foundations of systems programming and advanced concepts for producing software that provides services to computer hardware");
            information.Add("Through this study you will be able to demonstrate knowledge of the principles and techniques of process management, memory and file management, data protection, and distributed systems");
            information.Add("It discusses the concepts, structure and mechanisms of modern operating systems for systems programming, e.g., processes, concurrency, storage management, and so on");
            information.Add("It also looks at distributed systems and security issues that are required to support systems programming");
            information.Add("It builds upon the low level programming concepts introduced in CAB202: Microprocessors and Digital Systems");
            Unit CAB403 = new Unit("CAB403", "Systems Programming", information, "#80EE8B", announcements, assesment, resources);
            units.Add(CAB403);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This is an introductory unit that will provide you with the foundational skills and knowledge required for understanding, designing and analysing information systems");
            information.Add("The unit aims to develop an appreciation, and an ability to manage, the complexity of contemporary and future information systems and the domains in which they are used");
            information.Add("Further, it will provide you with the skills to design artefacts, fit for purpose and audience, that can be used to solve real-world problems related to information systems");
            information.Add("Unit content will play an important role in future units and a wide variety of professional IT activities");
            information.Add("This unit expands on knowledge acquired in IFB103 IT Systems Design by introducing conceptual modelling techniques that underpin most modern systems modelling languages");
            information.Add("Subsequent units will build on the conceptual modelling skills learned in this unit, for example, by applying it to the techniques covered in IAB203 BPM and IAB204 Business Requirements Analysis");
            Unit IAB201 = new Unit("IAB201", "Modelling Techniques for Information Systems", information, "#F3B15B", announcements, assesment, resources);
            units.Add(IAB201);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Web applications are widely in use both within enterprises and in consumer applications");
            information.Add("Developing Web applications faces significant challenges, including faster delivery of new innovations, robustness for change, and performance scalability");
            information.Add("The unit will address these challenges by using Model-View-Controller (MVC) frameworks to support rapid development of web applications");
            information.Add("The knowledge and skills developed in this unit are valuable for all IT professional roles – software engineers, business analyst and architects, enabling an understanding of software systems design practices and development practices");
            information.Add("This is an introductory unit and students will be exposed to web application development through a guided process of using well known frameworks such as CSS-Bootstrap, Python-Flask and JQuery");
            information.Add("It builds on concepts learnt in IFB103 and IFB105 and recommends knowledge of Python programming");
            Unit IAB207 = new Unit("IAB207", "Rapid Web Application Development", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(IAB207);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit continues after IAB201 and introduces business process management concepts: how organisations improve their business processes in terms of time, cost and quality");
            information.Add("It introduces process identification and process discovery");
            information.Add("Furthermore, it addresses the fundamentals of process modelling: model quality, correctness issues and modelling in BPMN's collaboration and choreography diagrams");
            information.Add("After this unit, IAB320 continues with other business process improvement steps");
            Unit IAB203 = new Unit("IAB203", "Business Process Modelling", information, "#EFE379", announcements, assesment, resources);
            units.Add(IAB203);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces you to the role, knowledge, skills and techniques required of a business analyst");
            information.Add("The unit focuses on the tools and methods used by a business analyst, as well as the soft skills such as creativity and communication, all of which are critical to successful business requirements analysis");
            Unit IAB204 = new Unit("IAB204", "Business Requirements Analysis", information, "#E1AAEC", announcements, assesment, resources);
            units.Add(IAB204);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit covers the essential activities in information systems lifecycle management");
            information.Add("An important role of business analysts and IT managers is to analyse and understand business strategies, capabilities, and objectives to define, select, and implement information systems within organizations to achieve their organizational objectives");
            information.Add("This unit provides students with skills and knowledge related to information systems definition, acquisition, development, integration, transformation, implementation, and maintenance within organisations");
            information.Add("This unit will expand skills  in analysing and designing an IT system from IFB103 Introduction to Systems Analysis and Design and their information systems modelling knowledge from IAB201 Modelling Techniques for Information Systems by introducing how information systems can be incorporated with business models, processes and strategic business needs");
            information.Add("Skills learned in this unit will be utilised and further developed in IAB301 Enterprise Architecture");
            Unit IAB305 = new Unit("IAB305", "Information Systems Lifecycle Management", information, "#AAECDE", announcements, assesment, resources);
            units.Add(IAB305);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Introduce you to the technologies that can be used to address challenges in managing fast incoming, voluminous, and varied data that is increasingly being relied on to make decisions in today's business environment");
            information.Add("You will develop practical skills in using modern data management technologies that will prepare you to be a data analyst, business analyst, solution architect, as well as enterprise architect");
            Unit IAB206 = new Unit("IAB206", "Modern Data Management", information, "#CD9864", announcements, assesment, resources);
            units.Add(IAB206);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit fosters developing process analysis, improvement, and design skills of students");
            information.Add("These skills and capabilities will prepare you to undertake the digital transformation challenges of today’s organisations");
            information.Add("You will understand and apply a variety of methods, tools, techniques, and approaches for organisational-wide process improvement initiatives");
            information.Add("You will be exposed to a robust selection of quantitative and qualitative analysis techniques as well as key process redesign paradigms used in the industry");
            information.Add("This will involve developing your knowledge and expertise in different process improvement methodologies such as Lean, Six Sigma and Process Reengineering using a hands-on teaching approach with real-life case studies to enable authentic learning outcomes");
            Unit IAB320 = new Unit("IAB320", "Business Process Improvement", information, "#BDD647", announcements, assesment, resources);
            units.Add(IAB320);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("In this unit you will draw on your knowledge and skills learnt in prior IT core units to learn how to problem solve with data for the purposes of extracting business insight");
            information.Add("Through the practical lab sessions you will explore the relationship between common business concerns and the data and analytics that can be used to address them, developing the skills to use a range of analytics techniques with a variety of data");
            information.Add("You will also have the opportunity to learn how to present analytics in a meaningful way for business use");
            information.Add("Through the workshops, you will be able to increase your understanding of different kinds of data, their importance to business, and why certain analytical and visualisation techniques can be used");
            Unit IAB303 = new Unit("IAB303", "Data Analytics for Business Insight", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(IAB303);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit will introduce you to the theoretical and practical requirements to build and understand social technology platforms, social networks, and digital communities");
            information.Add("You will learn concepts of social technology platforms practical manner, investigate the building blocks of successful digital communities and understand the critical design features");
            information.Add("Digital communities are becoming a key feature of the future economy with online communities and social networks are increasingly employed as part of the business model");
            information.Add("The success of Digital Communities varies wildly with some communities were successful and others were struggling");
            information.Add("This unit explores how to develop successful online communities by incorporating both a theoretical perspective and an architectural perspective");
            Unit IAB260 = new Unit("IAB260", "Social Technologies", information, "#80EE8B", announcements, assesment, resources);
            units.Add(IAB260);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("In IAB402 Information Systems Consulting, you will gain an appreciation of the management of consulting practices and an understanding of the consulting sector generally");
            information.Add("Having developed business requirements analysis skills in IAB305 to identify systems problems or opportunities and specify solution-approaches, Business Analysts and other IT professionals must be able to convincingly communicate these (problems, opportunities, requirements, solution-approach) to managers, colleagues and clients in the form of a proposal");
            information.Add("Many roles benefit from such specialised proposal writing and communication capabilities");
            information.Add("Organisations are increasingly moving to flatter, project-oriented, team structures, akin to consulting firms");
            information.Add("A better appreciation of the consulting process will be beneficial to students working in these modern organisations as IT professionals");
            information.Add("The unit will provide information on establishing a consulting practice and techniques to engage clients successfully");
            Unit IAB402 = new Unit("IAB402", "Information Systems Consulting", information, "#F3B15B", announcements, assesment, resources);
            units.Add(IAB402);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit covers Enterprise Architecture (EA) theory and practice, concerning the ways in which business and IT systems are planned and designed using modelling techniques");
            information.Add("EA focuses on organizational capability maps, which reflect what businesses do, independent of business");
            information.Add("The techniques for capturing different artefacts at business and IT levels relevant to systems planning will include business services, processes, information and resources");
            information.Add("Students will be taught how to develop a multi-layered EA based on state-of-the-art modelling techniques in TOGAF Archimate and UML");
            information.Add("Importantly, this unit extends your knowledge and skills to model, design and problem and pursue careers in EA, modelling, design and solution architecture of individual systems");
            information.Add("The unit links to and extends learning from previous units in Data and Information Management and Process Modelling");
            Unit IAB401 = new Unit("IAB401", "Enterprise Architecture", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(IAB401);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit builds on high school calculus by exploring derivatives, integrals and differential equations");
            information.Add("It also introduces the basic theory of matrices, vectors and complex numbers");
            information.Add("The ability to apply these concepts and techniques, and express real-world problems in mathematical language, is essential in quantitative fields such as science, business and technology");
            information.Add("This is an introductory unit, which attempts to establish foundational skills that you will extend in subsequent discpine-specific units");
            information.Add("This unit is particularly intended for students whose mathematics preparation does not include Queensland Senior Mathematics C or an equivalent");
            Unit MXB100 = new Unit("IAB401", "Introductory Calculus and Algebra", information, "#EFE379", announcements, assesment, resources);
            units.Add(MXB100);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Many real world phenomena are modelled by mathematical models whose solutions cannot be found analytically");
            information.Add("To solve these problems in practice, it is necessary to develop computational methods, algorithms and computer code");
            information.Add("This unit will introduce you to numerical methods for addressing fundamental problems in computational mathematics such as solving nonlinear ordinary differential equations, finding roots of nonlinear functions, constructing interpolating polynomials of data sets, computing derivatives and integrals numerically and solving linear systems of equations");
            information.Add("This is an introductory unit providing fundamental skills in computational mathematics and their practical implementation using relevant computational software");
            information.Add("This unit will be essential throughout the remaining parts of your degree");
            information.Add("MXB226 Computational Methods 1 builds on this unit by extending your computational and programming skills to more challenging problems and more sophisticated algorithms");
            Unit MXB103 = new Unit("MXB103", "Introductory Computational Mathematics", information, "#E1AAEC", announcements, assesment, resources);
            units.Add(MXB103);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces you to techniques of computation and simulation across a range of application areas in Science, Technology, Engineering and Mathematics (STEM)");
            information.Add("Computation and simulation are cornerstones of modern practice across STEM; practitioners skilled in these areas can explore behaviours of real-world systems that would be impractical or impossible to undertake using only theoretical or experimental means");
            information.Add("In this introductory unit, you will develop your computation and simulation skills through individual and collaborative problem-solving activities");
            information.Add("Further exploration is available through the faculty-wide second major or minor in Computational and Simulation Science");
            Unit MXB161 = new Unit("MXB161", "Computational Explorations", information, "#AAECDE", announcements, assesment, resources);
            units.Add(MXB161);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("With the rapid development in both computing hardware and its application to advanced scientific problems that require computational solutions, there is a need for IT, Maths and Science students to have a practical understanding of Computational and Simulation Science");
            information.Add("This unit aims to provide you with the knowledge to apply computational simulation techniques in a selection of application areas where the scientific problems are characterised by widely varying scales, both in space and time");
            information.Add("You will use relevant programming softwares to develop and implement simulation algorithms together with analysis of resulting data using multi-dimensional visualisation techniques");
            information.Add("You can further develop visualisation skills through units MXB262 Visualising Data and MXB362 Advanced Visualisation and Data Science, as well as extending your knowledge of computational science through the unit MXB361 Aspects of Computational Science");
            Unit MXB261 = new Unit("MXB261", "Modelling and Simulation Science", information, "#CD9864", announcements, assesment, resources);
            units.Add(MXB261);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Visualisation is critical for exploring and communicating science and engineering data");
            information.Add("Modern visualisation techniques and systems are needed to efficiently explore such data");
            information.Add("This unit introduces you to data visualisation concepts and techniques, along with practical experience exploring and dynamically visualising complex data");
            information.Add("You will develop an understanding of the fundamental concepts and techniques used in data visualisation through practical, real-world examples in contexts such as the environment, agriculture, industry, engineering, and healthcare");
            information.Add("You will follow the visualisation pipeline from importing, to visualising, to communicating data");
            information.Add("An emphasis will be placed on effective visual communication, and high-quality, fit-for-purpose representations of 2D, multi-dimensional, and network data");
            Unit MXB262 = new Unit("MXB262", "Visualising Data", information, "#BDD647", announcements, assesment, resources);
            units.Add(MXB262);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("With the rapid development in computing hardware, algorithms, AI and their applications to advanced scientific problems that require computational solutions, there is a need for IT, Maths, Science and Engineering students to have a practical understanding of Computational Science");
            information.Add("This unit aims to provide you with the knowledge to apply computational techniques for problem-solving in a variety of application areas you are likely to encounter in your early careers, whether in industry or in further study");
            information.Add("This unit will equip you with an understanding of different application areas requiring modern computational solutions, particularly as they relate to complex systems; you will have the opportunity to implement such computational techniques and analyse and interpret the resulting data");
            Unit MXB361 = new Unit("MXB361", "Aspects of Computational Science", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(MXB361);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Data visualisation is an essential element of modern computational and data science");
            information.Add("It provides powerful tools for investigating, understanding, and communicating the large amounts of data that can be generated by computational simulations, scientific instruments, remote sensing, or the Internet of Things");
            information.Add("The aim of this unit is to explore the issues, theories, and techniques of advanced data visualisation");
            information.Add("This unit develops theoretical and practical understandings of the major directions and issues that confront the field");
            information.Add("A selected number of advanced data visualisation techniques will be examined in detail through specific examples");
            information.Add("The practicals will reinforce lecture content and extend your applied skills and knowledge in data visualisation, including specific methods");
            information.Add("A focus of the unit is the development of real world data visualisation skills and experience, based on a major data visualisation case study");
            Unit MXB362 = new Unit("MXB362", "Advanced Visualisation and Data Science", information, "#80EE8B", announcements, assesment, resources);
            units.Add(MXB362);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces probability and shows you how to apply its concepts to solve practical problems");
            information.Add("The unit will lay the foundations for further studies in statistics, operations research and other areas of mathematics and help you to develop your problem-solving and modelling skills");
            information.Add("The topics covered include: basic probability rules, conditional probability and independence, discrete and continuous random variables, bivariate distributions, central limit theorem, and introduction to Markov chains");
            information.Add("This unit is appropriate for those requiring an introduction to, or a refresher in, probability");
            information.Add("The concepts in this unit will be extended in MXB241");
            Unit MXB101 = new Unit("MXB101", "Probability and Stochastic Modelling 1", information, "#F3B15B", announcements, assesment, resources);
            units.Add(MXB101);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Statistical modelling provides methods for analysing data to gain insight into real-world problems");
            information.Add("The aim of this unit is to introduce a wide range of fundamental statistical modelling and data analysis techniques, and demonstrate the role they play in drawing inferences in real-world problems");
            information.Add("This unit is designed around the exploration of contemporary and important issues through the analysis of real data sets, while simultaneously and necessarily building your statistical modelling expertise");
            information.Add("You will learn how to propose research questions, analyse real data sets to attempt to answer these questions, and draw inferences and conclusions based on your findings");
            information.Add("The importance of ethical considerations when dealing with real data sets will be emphasised");
            information.Add("The R programming language will be introduced, and you will gain experience and build your expertise in using this industry-leading software to conduct statistical analyses");
            Unit MXB107 = new Unit("MXB107", "Introduction to Statistical Modelling", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(MXB107);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Many applications within Computer Science use standard mathematical methods as tools for analysing and processing information");
            information.Add("This unit provides an introduction to some basic mathematical methods that will be useful to you in your further studies in Computer Science, including basic matrix and vector operations (storing and manipulating geometrical or other information), introductory probability and statistics (modelling random events) and basic concepts in differentiation and integration (modelling rates of change and accumulated quantities)");
            information.Add("By introducing the fundamental concepts underlying these methods and developing your skills in using these methods, the unit will provide a foundation for later studies in computer science, in fields such as computer graphics, games design, machine learning, robotics, information retrieval and data mining");
            Unit MZB151 = new Unit("MZB151", "Mathematical Tools for Computing", information, "#EFE379", announcements, assesment, resources);
            units.Add(MZB151);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Data is becoming central to every organization's decision making process, and the demand for data savvy modelers and software engineers is rapidly increasing");
            information.Add("Modern computational approaches to data analysis have to enable users to acquire, manage, interpret, present and disseminate large volumes of heterogeneous data");
            information.Add("Data science is a synthesis of statistics, mathematics, machine learning and computer science, and uses tools, techniques, and approaches from all of these fields to extract information from datasets");
            information.Add("This unit will introduce you to a wide range of Data Science methods and theories to model and analyze data");
            Unit CAB220 = new Unit("CAB220", "Fundamentals of Data Science", information, "#E1AAEC", announcements, assesment, resources);
            units.Add(CAB220);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("The ability to collect, analyse, manipulate, understand and report data effectively is important in any work environment");
            information.Add("This is particularly true in business where learning to deal with randomness, variation and uncertainty is a vital skill for anyone applying their knowledge to inform business decisions");
            information.Add("This introductory unit is designed to ensure that students gain an appreciation of the basic tools necessary to develop and apply this skill set");
            information.Add("It introduces the fundamental concepts and statistical methods for data analysis, and students will learn about different types and sources of data, and techniques for displaying and analysing data to make business decisions");
            information.Add("Students will gain practical data manipulation skills using Microsoft Excel, and practise many of the quantitative techniques applicable to all disciplines, which will be used throughout their further studies");
            Unit BSB123 = new Unit("BSB123", "Data Analysis", information, "#AAECDE", announcements, assesment, resources);
            units.Add(BSB123);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Data analytics has become a popular way to support decision-making by turning an organization's large collection of data into useful knowledge about their customers and business processes");
            information.Add("Data analytics has direct applications in several fields such as social networks, business processes, search-engines, e-commerce, digital libraries, bioinformatics and web information systems");
            information.Add("This unit provide fundamental knowledge and skills of data analytics to help with data-driven decision making");
            information.Add("You will learn the different types of data mining techniques to apply classification, clustering and association mining");
            information.Add("You will learn how the processing can be applied to text and web usage data");
            information.Add("This is an introductory unit and the knowledge and skills developed in this unit are relevant to all IT professionals");
            information.Add("It builds on CAB220 - Fundamentals of Data Science which introduces the basic concepts of data manipulation");
            Unit CAB330 = new Unit("CAB330", "Data and Web Analytics", information, "#CD9864", announcements, assesment, resources);
            units.Add(CAB330);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Whether you will be a business analyst, a process owner, a solution architect or a software engineer, it is essential that you understand the principles and value of business process automation, in order to fully realise the benefits of Business Process Management");
            information.Add("This unit introduces the fundamentals of 'business process automation'");
            information.Add("You will learn how to develop an executable business process based on a business-oriented process model");
            information.Add("You will practice how to automate an executable process using a business process management system (BPMS) and how to monitor its progress");
            information.Add("The unit further presents various post-execution techniques for analysing the behaviour of automated processes");
            information.Add("The hands-on approach allows students to design, control and analyse automated business processes using a variety of well-known business process technologies");
            Unit IAB321 = new Unit("IAB321", "Business Process Technologies", information, "#BDD647", announcements, assesment, resources);
            units.Add(IAB321);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces the fundamentals of enterprise systems configuration");
            information.Add("It uses a leading enterprise system to demonstrate how organisations configure these systems to meet organisational and user requirements");
            information.Add("Configuring an enterprise system is a substantial undertaking that must take into account technical, business and environmental considerations");
            information.Add("This unit commences by introducing core enterprise systems concepts related to organizational structures, process models, and data models");
            information.Add("This knowledge then serves as the foundation to configuring financial, sales, procurement, and production related functionalities");
            information.Add("With enterprise systems forming the IT backbone of most large organisations, the knowledge and skills learnt in this unit are relevant for any IT professional");
            Unit IAB250 = new Unit("IAB250", "Enterprise Systems Configuration", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(IAB250);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit provides knowledge and skills in designing businesses and systems in Cloud settings. It covers many aspects of the design in business models and IT systems, it introduces skills for developing business models and IT systems architecture, relevant for the Cloud");
            information.Add("In addition, you will learn key management practices to develop business cases, manage businesses and IT systems as services, and understand privacy, security and regulatory policy that governs the use of cloud services");
            information.Add("Through the unit, you will be exposed to authentic industry cases drawn from key sectors such as banking, retail and government");
            information.Add("The knowledge and skills the unit provides are widely used by management consulting firms and IT professional roles such as Enterprise Architects, Business Architects, Solution Architects and Business Analysts");
            information.Add("The unit uses knowledge provided in IAB305 Information Systems Lifecycle Management, applied for Business Cloud applications");
            Unit IAB351 = new Unit("IAB351", "Business in the Cloud", information, "#80EE8B", announcements, assesment, resources);
            units.Add(IAB351);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Organisations invest substantial resources in acquiring enterprise systems from vendors such as SAP and Oracle, presumably expecting positive impacts to the organisation and its functions");
            information.Add("Despite the optimistic objectives, failure of enterprise systems to attain benefits is common. This unit provides the knowledge and skills into how to successfully manage enterprise systems projects throughout their entire lifecycle, from acquisition to use to retirement");
            information.Add("Drawing on real-life case studies, concepts related to requirements analysis, implementation strategy, training, knowledge management, and change management will be discussed throughout the unit");
            information.Add("The knowledge and skills taught in this unit are relevant for anyone pursuing a career involving the management of large IT projects");
            Unit IAB352 = new Unit("IAB352", "Enterprise Systems Mangement", information, "#F3B15B", announcements, assesment, resources);
            units.Add(IAB352);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("An ability to understand the basic functions of management and apply that knowledge to contemporary practice are key skills for competent business professionals and informed, effective managers");
            information.Add("This unit provides insights into current business issues and practices using real world cases and practitioner readings");
            information.Add("The unit introduces students to foundational theories and practices of management and organisations, with an emphasis on the conceptual and people skills that are needed in all areas of management and organisational life");
            information.Add("The unit acknowledges that organisations exist in an increasingly competitive environment where the emphasis will be on knowledge and the ability to learn, change and innovate");
            information.Add("Organisations are viewed from individual, group, corporate and external environmental perspectives, and the unit provides a foundation for students studying business or wishing to understand more thoroughly the role of organisations within society");
            Unit BSB115 = new Unit("BSB115", "Management", information, "#A1F1F4", announcements, assesment, resources);
            units.Add(BSB115);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces the components of a mobile ubiquitous system, including stand alone and wearable sensors and wireless network protocols");
            information.Add("It introduces the Internet of Things context and develops the skills in designing products and applications that use mobile and ubiquitous sensors and smart devices");
            information.Add("The ability to critically review real case studies, expand awareness of interconnections between technologies, networks and user contexts and design a solution to a smart IT context problem is a requirement for a range of graduate positions");
            information.Add("This is the first unit in the Mobile Application Development minor and builds on the skills that you developed in IFB103 IT Systems Design, and IFB104 Building IT Systems");
            information.Add("IAB330 Mobile Application Development builds on this unit in which you design and build a working prototype system that uses mobile and ubiquitous system components");
            Unit IAB230 = new Unit("IAB230", "Design of Enterprise IoT", information, "#EFE379", announcements, assesment, resources);
            units.Add(IAB230);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This foundational unit introduces the basics of Artificial Intelligence (AI) ranging from Intelligent Search techniques to Machine Learning");
            information.Add("AI strives to build intelligent entities as well as understand them");
            information.Add("AI has produced many significant products; from AI chess champions to state of the art schedulers and planners");
            information.Add("This unit introduces state representations, techniques and architectures used to build intelligent systems");
            information.Add("It covers topics such as heuristic search, machine learning (including deep neural networks) and probabiObservableCollectionic reasoning");
            information.Add("The ability to formalise a given problem in the language/framework of relevant AI methods (for examples, a search problem, a planning problem, a classification problem, etc) and understand a fast evolving field is a requirement for a range of graduate entry software engineer positions");
            information.Add("This unit lays the foundations for further studies in Games, Robotics, Pattern Recognition, Information Retrieval, Data Mining and Intelligent Web Agents");
            Unit CAB320 = new Unit("CAB320", "Artificial Intelligence", information, "#E1AAEC", announcements, assesment, resources);
            units.Add(CAB320);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("This unit introduces you to the components, systems and mathematical foundations of robotics and computer vision");
            information.Add("The unit introduces the technologies and methods used in the design and programming of modern intelligent robots, and encourages critical thinking about the use of robotic technologies in various applications");
            information.Add("The unit emphasizes the practical application of robotic theory to the design and synthesis of robotic systems that respond accurately and repeatably");
            Unit EGB339 = new Unit("EGB339", "Introduction to Robotics", information, "#AAECDE", announcements, assesment, resources);
            units.Add(EGB339);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Mobile, tablet and wearable devices are the emerging computing platforms, resulting in a high demand for creative developers to build innovative cross platform applications, and given the variety of platforms there is a major skills shortage");
            information.Add("This unit aims to provide the theoretical and technical knowledge and skills to design, develop, and publish mobile apps");
            information.Add("You will extend your design and development skills by working collaboratively in multi-cultural and multi-disciplinary teams to acquire a solid practical foundation for the design and development of innovative mobile and pervasive systems");
            Unit IAB330 = new Unit("IAB330", "Mobile Application Development", information, "#CD9864", announcements, assesment, resources);
            units.Add(IAB330);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("The World Wide Web is the most important platform for software systems and an integral part of modern life");
            information.Add("Many companies owe their existence to the web, through applications deployed over the Internet using web protocols");
            information.Add("All IT professionals require a good understanding of the web and its architecture, especially software developers and those tasked with maintaining and implementing web-based software systems. This unit is a technical introduction to modern web computing");
            information.Add("You will design and implement clean and responsive user interfaces, taking account of accessibility and internationalisation");
            information.Add("We will provide an introduction to JavaScript and you will use it throughout the semester, gaining practical experience with HTML, CSS and frameworks such as React on the client side, and node.js, Express and the node ecosystem on the server side");
            information.Add("You will understand security threats and their mitigation and gain practical experience deploying an internet facing web server using HTTPS");
            Unit CAB230 = new Unit("CAB230", "Web Computing", information, "#BDD647", announcements, assesment, resources);
            units.Add(CAB230);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Cybersecurity breaches, from database hacking to malware campaigns, are increasing");
            information.Add("The interconnectedness of information systems means actions of individuals may impact on others on a global scale");
            information.Add("This unit is important in developing an understanding of the challenges involved in protecting information, introducing essential information security concepts. Security goals including confidentiality, integrity, availability, authentication and non-repudiation are defined");
            information.Add("Threats to information and vulnerabilities that could be exploited are identified");
            information.Add("Technical and non-technical measures to provide security for information are discussed in areas including access control, cryptography, and network communications");
            information.Add("Security management standards and guidelines on best practice implementation are reviewed");
            information.Add("You can take this unit as a stand-alone course to raise your information security awareness, or as a pathway into information security units, including network security and cryptography");
            Unit CAB240 = new Unit("CAB240", "Information Security", information, "#80EE8B", announcements, assesment, resources);
            units.Add(CAB240);

            information = new ObservableCollection<string>();
            announcements = new ObservableCollection<Announcement>();
            assesment = new ObservableCollection<Assesment>();
            resources = new ObservableCollection<Resources>();
            information.Add("Worth 12 credit points");
            information.Add("Gardens Point Campus");
            information.Add("Cloud Computing is among the most important developments in the IT industry in recent years, and one which has received enormous attention");
            information.Add("Cloud is a natural progression from earlier trends in service and infrastructure outsourcing and virtualisation, but is distinguished by its elasticity and scale: service and infrastructure provisioning may change rapidly in response to variations in demand, allowing clients to cater for unexpected spikes in load without tying up capital in expensive and potentially underutilised assets");
            information.Add("Cloud services and technologies are becoming increasingly diverse and sophisticated, moving rapidly from the initial, 'bare metal' offerings of a few years ago, and providing a rich set of options and APIs");
            information.Add("This unit provides a technically oriented introduction to Cloud Computing, giving you experience in developing modern cloud applications and deploying them to the public clouds of the major vendors");
            Unit CAB432 = new Unit("CAB432", "Cloud Computing", information, "#F3B15B", announcements, assesment, resources);
            units.Add(CAB432);

            return units;
        }
    }
}

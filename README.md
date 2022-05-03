<b>1. Overview</b>   
   This is console app repository for analyizing Robots behaviour.
   
<b>2. Input</b>  
   The defined grid size is 5x5 (but it can be manipulated by changing data in appsettings.json file in TRG.IO project).
   It is possible to upload data as a .txt file or type commands manually in console window.
   
   Allowed Robot Commends:  
   PLACE_ROBOT ROW,COL,FACING  
   PLACE_WALL ROW,COL  
   REPORT  
   MOVE  
   LEFT  
   RIGHT  
   
   where ROW and COL are integers value and FACING is one of the following: NORTH, SOUTH, EAST, WEST
   
<b>3. Output</b>  
   The console line is output of this application, whenever the command REPORT is called.
   
<b>4. Run application</b>  
  Requirements:  
   - Visual Studio 2022
   
  Steps:   
   a) clone or download this repository (MMD-ToyRobotGame) into your local machine,  
   b) compile application and run it

<b>5. Run application</b>    
  Test files are prepared in TestData directory

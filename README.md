# This is currently Windows ONLY, not sure when that will change

# LoonieTunes
Hey everyone! This is a windows Desktop application, which I have named "Loonie Tunes". It is designed to analyze the AppDate.lua file that TradeSkillMaster Desktop application outputs. It will generate Final csv document, or in the application a csv you can copy. This can then be pasted into a spreadsheet as backend pricing data.

## Installation
To install download the LoonieTunes.msi file, and install the application.

## Pre-requisites
1. You will need TradeSkillMaster Desktop application installed
2. You will need to know the path of the AppData.lua folder. General path within the WoW Directory is \Blizzard\World of Warcraft\_retail_\Interface\AddOns\TradeSkillMaster_AppHelper\AppData.lua

## How this works

### The Code
As stated above, the Desktop application will read the AppData.lua file TSM outputs. It will pull all the items within that file and match their ids with appropriate names for those items. It will then create a final csv with which you can use however you would like. In this case I would suggest you use it as backend pricing data for a spreadsheet, so you can see where profits are in your professions in World of Warcraft.

## Steps

### Step: 1
Select your region from the drop down menu beside the Path textbox and then click "Browse..." to find your AppData.lua file that TSM builds. It is found in your WoW Directory addons folder here, \Blizzard\World of Warcraft\_retail_\Interface\AddOns\TradeSkillMaster_AppHelper\AppData.lua 

### Step: 2
The Realm drop down will populate with the realms you have selected for TSM to support, choose which realm you would like the pricing data for.

### Step: 3
Click the "Convert" button to proceed with pulling out the pricing data for your selected realm to build the final CSV file.

### Step: 4
Once the build process is complete, click "Copy CSV to Clipboard" to copy the contents of the final built CSV file to paste in a spreadsheet.

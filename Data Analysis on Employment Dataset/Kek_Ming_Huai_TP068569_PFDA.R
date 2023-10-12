
library(ggplot2)
library(readr)
library(dplyr)
library(stringr)

# Importing and reading file
employee_attrition <- read_csv("C:\\Users\\ACER\\OneDrive - Asia Pacific University\\Documents\\Class\\Year 2\\Sem 1\\R\\Assignment\\employee_attrition.csv")

# To get a list of all the headings in the dataset
head(employee_attrition)

# To show the format of each column in the dataset
str(employee_attrition)

# To provide a simple summary of the dataset
summary(employee_attrition)

# To check if there are any missing values in the dataset
sum(is.na(employee_attrition))

# Remove columns that are duplicates of another column and useless columns
employee_attrition <- employee_attrition[, !(names(employee_attrition) %in% c("gender_full", "terminatedate_key", "birthdate_key"))]

# Remove duplicate records of employee
employee_attrition <- employee_attrition %>%
  group_by(EmployeeID) %>%
  filter(STATUS_YEAR == max(STATUS_YEAR))

#Convert recorddate_key to Date format
employee_attrition$recorddate_key <- as.Date(employee_attrition$recorddate_key, format = "%m/%d/%Y %H:%M")

#Sort by date and EmployeeID
employee_attrition <- employee_attrition %>% arrange(EmployeeID, desc(recorddate_key))

# Correcting typos in the dataset
employee_attrition$termreason_desc <- str_replace(employee_attrition$termreason_desc, "Resignaton", "Resignation")
employee_attrition$job_title <- str_replace(employee_attrition$job_title, "CHief Information Officer", "Chief Information Officer")

# Remove records that are both active and terminated on the same year
active_rows <- subset(employee_attrition, STATUS == "ACTIVE")
terminated_rows <- subset(employee_attrition, STATUS == "TERMINATED")
merged_rows <- merge(active_rows, terminated_rows, by = c("EmployeeID", "STATUS_YEAR"))
employee_attrition <- filter(employee_attrition, !(STATUS == "ACTIVE" & EmployeeID %in% merged_rows$EmployeeID))

### QUESTION 1
## Analysis 1
# Extract the lines where the termreason_desc is "Retirement" and termtype_desc is "Voluntary"
retirement_data <- employee_attrition %>%
  filter(termreason_desc == "Retirement" & termtype_desc == "Voluntary")

# Count how many lines have the same age and gender
retirement_data <- retirement_data %>%
  group_by(age, gender_short) %>%
  summarize(count = n())

# Plot the bar chart
ggplot(retirement_data, aes(x = age, y = count, fill = gender_short)) +
  geom_bar(stat="identity", position = "stack") +
  geom_text(aes(label = count), vjust = 1.5) +
  theme(axis.text.x = element_text(angle = 90, hjust = 1)) +
  scale_x_continuous(breaks = seq(0, 70, by = 5), limits = c(55, 70))

## Analysis 2
# Extract the lines where the employee is terminated and where the reason is not Retirement
terminated_data <- employee_attrition %>%
  filter(STATUS == "TERMINATED" & termreason_desc == "Resignation")

# Count how many lines have the same age and gender_short
terminated_data <- terminated_data %>%
  group_by(age, gender_short) %>%
  summarize(count = n())

# Plot the line chart
ggplot(terminated_data, aes(x = age, y = count, color = gender_short)) +
  geom_line() +
  geom_text(aes(label = count), vjust = 1.5) +
  scale_x_continuous(breaks = seq(18, 70, by = 1), limits = c(19,63)) +
  theme(axis.text.x = element_text(angle = 45, hjust = 1))

## Analysis 3
# Extract the lines where the STATUS is "Terminated" and termreason_desc is "Resignation"
terminated_data <- employee_attrition %>%
  filter(STATUS == "TERMINATED" & termreason_desc == "Resignation")

# Count how many lines have the same length_of_service and gender_short
terminated_data <- terminated_data %>%
  group_by(length_of_service, gender_short) %>%
  summarize(count = n())

# Plot the line graph
ggplot(terminated_data, aes(x = length_of_service, y = count, color = gender_short)) +
  geom_line() +
  geom_text(aes(label = count), vjust = 1.5) +
  theme(axis.text.x = element_text(angle = 90, hjust = 1)) +
  scale_x_continuous(breaks = seq(0, 25, by = 1), limits = c(0,22))

## Analysis 4
# Count the employees in each position that has been terminated
job_portion <- employee_attrition %>%
  filter(STATUS == "TERMINATED" & termreason_desc == "Resignation") %>%
  group_by(job_title) %>%
  summarize(count = n())

# Count all the employees that have been or is still in that job position
job_total <- employee_attrition[employee_attrition$job_title %in% job_portion$job_title, ] %>%
  group_by(job_title) %>%
  summarize(count = n())

# Find out the percentage of terminated employee by dividing
job_percentage <- (job_portion$count / job_total$count)*100
job_percentage <- data.frame(job_percentage = job_percentage)

# Plot the bar chart
ggplot(job_percentage, aes(x = job_portion$job_title, y = job_percentage, fill = job_percentage)) +
  geom_bar(stat = "identity") +
  scale_fill_gradient(low = "lightblue", high = "darkblue") +
  geom_text(aes(label = round(job_percentage, 2)), vjust = -0.5) +
  labs(x = "Job Title", y = "Percentage of Terminated Employees", 
       title = "Percentage of Terminated Employees by Job Title")

## Analysis 5
# Extract lines where job_title is "HRIS Analyst"
hris_analyst_data <- employee_attrition[employee_attrition$job_title == "HRIS Analyst", ]

# Count the lines where store_name is the same
hris_analyst_counts <- table(hris_analyst_data$store_name)

# Sort the counts in descending order
hris_analyst_counts_sorted <- sort(hris_analyst_counts, decreasing = TRUE)

# Plot a bar chart of count against store_name
barplot(hris_analyst_counts_sorted, 
        main = "HRIS Analyst Employee Counts by Store Name", 
        xlab = "Store Name", 
        ylab = "Number of Employees",
        names.arg = names(hris_analyst_counts_sorted), 
        las = 2)

# Extract lines where job_title is "Cashier"
cashier_data <- employee_attrition[employee_attrition$job_title == "Cashier", ]

# Count the lines where store_name is the same
cashier_counts <- table(cashier_data$store_name)

# Sort the counts in descending order
cashier_counts_sorted <- sort(cashier_counts, decreasing = TRUE)

# Plot a bar chart of count against store_name
barplot(cashier_counts_sorted, 
        main = "Cashier Employee Counts by Store Name", 
        xlab = "Store Name", 
        ylab = "Number of Employees",
        names.arg = names(cashier_counts_sorted), 
        las = 2)

# Extract lines where job_title is "Shelf Stocker"
shelf_stocker_data <- employee_attrition[employee_attrition$job_title == "Shelf Stocker", ]

# Count the lines where store_name is the same
shelf_stocker_counts <- table(shelf_stocker_data$store_name)

# Sort the counts in descending order
shelf_stocker_counts_sorted <- sort(shelf_stocker_counts, decreasing = TRUE)

# Plot a bar chart of count against store_name
barplot(shelf_stocker_counts_sorted, 
        main = "Shelf Stocker Employee Counts by Store Name", 
        xlab = "Store Name", 
        ylab = "Number of Employees",
        names.arg = names(shelf_stocker_counts_sorted), 
        las = 2)

# Extract lines where job_title is "Dairy Person"
dairy_person_data <- employee_attrition[employee_attrition$job_title == "Dairy Person", ]

# Count the lines where store_name is the same
dairy_person_counts <- table(dairy_person_data$store_name)

# Sort the counts in descending order
dairy_person_counts_sorted <- sort(dairy_person_counts, decreasing = TRUE)

# Plot a bar chart of count against store_name
barplot(dairy_person_counts_sorted, 
        main = "HRIS Analyst Employee Counts by Store Name", 
        xlab = "Store Name", 
        ylab = "Number of Employees",
        names.arg = names(dairy_person_counts_sorted), 
        las = 2)

## Analysis 6
# Only extract employee that has been terminated
employee_terminated <- employee_attrition %>% filter(STATUS == "TERMINATED")

ggplot(employee_terminated, aes(x = gender_short, fill = termreason_desc)) +
  geom_bar() +
  labs(x = "Gender", y = "Count", title = "Count of Terminations by Gender and Reason")

# Create a new data frame with the count of each gender value
gender_data <- employee_attrition %>%
  group_by(gender_short) %>%
  summarise(Count = n())

# Plot a bar chart of count against gender using ggplot2
ggplot(gender_data, aes(x = gender_short, y = Count)) +
  geom_bar(stat = "identity", fill = "orchid") +
  ggtitle("Employee Counts by Gender") +
  xlab("Gender") +
  ylab("Number of Employees")

## Analysis 7
# Count the employees in each position that has been terminated
department_portion <- employee_attrition %>%
  filter(STATUS == "TERMINATED" & termreason_desc == "Resignation") %>%
  group_by(department_name) %>%
  summarize(count = n())

# Count all the employees that have been or is still in that job position
department_total <- employee_attrition[employee_attrition$department_name %in% department_portion$department_name, ] %>%
  group_by(department_name) %>%
  summarize(count = n())

# Find out the percentage of terminated employee by dividing
department_percentage <- (department_portion$count / department_total$count)*100
department_percentage <- data.frame(department_percentage = department_percentage)

# Plot the bar chart
ggplot(department_percentage, aes(x = department_portion$department_name, y = department_percentage)) +
  geom_bar(stat = "identity", fill = "steelblue") +
  geom_text(aes(label = round(department_percentage, 2)), vjust = -0.5) +
  labs(x = "Department Name", y = "Percentage of Terminated Employees", 
       title = "Percentage of Terminated Employees by Department")

## Analysis 8
# Remove rows where STATUS is ACTIVE
employee_inactive <- subset(employee_attrition, STATUS != "ACTIVE")

# Extract city_name and length_of_service columns
city_service <- subset(employee_inactive, select = c("city_name", "length_of_service"))

# Calculate the total number of employees in each city
city_counts <- as.data.frame(table(city_service$city_name))
colnames(city_counts) <- c("city_name", "employee_count")

# Reorder the levels of the city_name factor in city_service according to employee_count
city_service$city_name <- factor(city_service$city_name, levels = city_counts$city_name[order(-city_counts$employee_count)])

# Create a boxplot for each city_name in the desired order
ggplot(city_service, aes(x = city_name, y = length_of_service)) +
  geom_boxplot() +
  xlab("City") +
  ylab("Length of Service") +
  ggtitle("Average Length of Service by Origin City of Employee, Sorted by Employee Count") +
  theme(axis.text.x = element_text(angle = 90, hjust = 1)) +
  scale_x_discrete(labels = function(x) str_wrap(x, width = 10))

## Analysis 9
# Extract rows where the STATUS is "TERMINATED"
terminated_employees <- subset(employee_attrition, STATUS == "TERMINATED")

# Group the terminated employees by termination year and reason, and count the number of employees in each group
terminated_counts <- terminated_employees %>%
  group_by(STATUS_YEAR, termreason_desc) %>%
  summarize(count = n())

# Create a bar plot of terminated employees by termination year and reason
ggplot(terminated_counts, aes(x = STATUS_YEAR, y = count, fill = termreason_desc)) +
  geom_bar(stat = "identity", position = "dodge") +  
  geom_text(aes(label = count), position = position_dodge(width = 0.9), vjust = -0.5) +
  xlab("Termination Year") +
  ylab("Number of Terminated Employees") +
  ggtitle("Terminated Employees by Termination Reason and Year") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1)) +
  scale_x_continuous(breaks = seq(2000, 2020, by = 1), limits = c(2005.5, 2015.5))

# Extract the rows where STATUS = "TERMINATED"
terminated_employees <- subset(employee_attrition, STATUS == "TERMINATED")

# Count the rows where the STATUS_YEAR is the same
terminated_counts <- as.data.frame(table(terminated_employees$STATUS_YEAR))

# Create a plot of total terminated employees per year
ggplot(terminated_counts, aes(x = Var1, y = Freq)) +
  geom_bar(stat = "identity") +
  xlab("Termination Year") +
  ylab("Count") +
  ggtitle("Terminated Employees by Year") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1))

### Question 2
## Analysis 1
#Subset the employee_attrition dataframe to include only terminated employees who resigned
resigned_data <- subset(employee_attrition, termreason_desc == "Resignation")

#Group by STATUS_YEAR and count resigned employees
resigned_count <- resigned_data %>%
  group_by(STATUS_YEAR) %>%
  summarize(count = n())

#Fit a linear regression model to the resigned employees
resigned_lm <- lm(count ~ STATUS_YEAR, data = resigned_count)

#Create a data frame for the predicted values
pred_data <- data.frame(STATUS_YEAR = 2016:2020, termreason_desc = "Resignation")

#Use the fitted model to predict the number of resignations
pred_data$count <- predict(resigned_lm, newdata = pred_data)

#Plot the observed and predicted resignation counts
ggplot(resigned_count, aes(x = STATUS_YEAR, y = count)) +
  geom_line(size = 1) +
  geom_line(data = pred_data, aes(x = STATUS_YEAR, y = count), linetype = "dotted", size = 1) +
  labs(title = "Employee Resignations by Year",
       x = "Year",
       y = "Count") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1),
        panel.spacing = unit(0.5, "cm")) +
  scale_x_continuous(breaks = seq(2006, 2020, by = 1), limits = c(2006, 2020))

#Subset the employee_attrition dataframe to include only terminated employees who retired
retirement_data <- subset(employee_attrition, termreason_desc == "Retirement")

#Group by STATUS_YEAR and count retired employees
retirement_count <- retirement_data %>%
  group_by(STATUS_YEAR) %>%
  summarize(count = n())

#Fit a linear regression model to the retired employees
retirement_lm <- lm(count ~ STATUS_YEAR, data = retirement_count)

#Create a data frame for the predicted values
pred_data <- data.frame(STATUS_YEAR = 2016:2020, termreason_desc = "Retirement")

#Use the fitted model to predict the number of retirements
pred_data$count <- predict(retirement_lm, newdata = pred_data)

#Plot the observed and predicted retirement counts
ggplot(retirement_count, aes(x = STATUS_YEAR, y = count)) +
  geom_line(size = 1) +
  geom_line(data = pred_data, aes(x = STATUS_YEAR, y = count), linetype = "dotted", size = 1) +
  labs(title = "Employee Retirement by Year",
       x = "Year",
       y = "Count") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1),
        panel.spacing = unit(0.5, "cm")) +
  scale_x_continuous(breaks = seq(2006, 2020, by = 1), limits = c(2006, 2020))

## Analysis 2
# Importing and reading file
employee_attrition_another <- read.csv("C:\\Users\\ACER\\OneDrive - Asia Pacific University\\Documents\\Class\\Year 2\\Sem 1\\R\\Assignment\\employee_attrition.csv")

# Remove columns that are duplicates of another column and useless columns
employee_attrition_another <- employee_attrition_another[, !(names(employee_attrition_another) %in% c("gender_full", "terminatedate_key"))]

# Remove rows where STATUS is not ACTIVE
employee_inactive <- subset(employee_attrition_another, STATUS == "ACTIVE")

# Count the total number of employees for each year
employee_count <- table(employee_inactive$STATUS_YEAR)

# Create a data frame of the counts and years
employee_counts <- data.frame(year = as.numeric(names(employee_count)), count = as.numeric(employee_count))

# Fit a polynomial regression model
poly_model <- lm(count ~ poly(year, 3), data = employee_counts)

# Predict the number of employees for each year from 2016 to 2020
new_years <- data.frame(year = 2016:2020)
predictions <-predict(poly_model, newdata = new_years)

# Combine the predicted values with the original data
employee_counts_pred <- rbind(employee_counts,data.frame(year = new_years$year, count = predictions))

# Plot the predicted values along with the original data
ggplot(employee_counts_pred, aes(x = year, y = count)) +
  geom_line(color = "red", size = 1, linetype = "dotted") + # original data line
  geom_line(data = employee_counts_pred[10:15,], aes(x = year, y = count), color = "blue", size = 1, linetype = "dotted") + # predicted data line
  xlab("Year") +
  ylab("Number of Employees") +
  ggtitle("Total Number of Employees by Year") +
  scale_x_continuous(breaks = seq(min(employee_counts_pred$year), max(employee_counts_pred$year), by = 1))

## Analysis 3
# Subset the data to only include active employees
employee_active <- subset(employee_attrition_another, STATUS == "ACTIVE")

# Count the number of employees for each gender and year
employee_counts <- aggregate(EmployeeID ~ STATUS_YEAR + gender_short, data = employee_active, FUN = length)

# Rename the columns
colnames(employee_counts) <- c("Year", "Gender", "Count")

# Convert the year column to numeric
employee_counts$Year <- as.numeric(employee_counts$Year)

# Fit a polynomial regression model for each gender
female_model <- lm(Count ~ poly(Year, 3), data = employee_counts[employee_counts$Gender == "F",])
male_model <- lm(Count ~ poly(Year, 3), data = employee_counts[employee_counts$Gender == "M",])

# Predict the number of employees for each gender and year from 2016 to 2020
new_years <- data.frame(Year = 2016:2020)

female_predictions <- predict(female_model, newdata = new_years)
male_predictions <- predict(male_model, newdata = new_years)

# Combine the predicted values with the original data
employee_counts_pred <- rbind(employee_counts,
                              data.frame(Year = rep(new_years$Year, 2),
                                         Gender = rep(c("F", "M"), each = 5),
                                         Count = c(female_predictions, male_predictions)))

# Create a plot with one line for each gender
ggplot(employee_counts_pred, aes(x = Year, y = Count, color = Gender)) +
  geom_line(data = employee_counts, size = 1) + # actual data line
  geom_line(data = employee_counts_pred[employee_counts_pred$Year >= 2016,], size = 1, linetype = "dotted") + # predicted data line
  xlab("Year") +
  ylab("Number of Employees") +
  ggtitle("Total Number of Employees by Year and Gender") +
  scale_x_continuous(breaks = seq(min(employee_counts$Year), max(employee_counts_pred$Year), by = 1)) +
  scale_color_manual(values = c("blue", "red")) +
  theme_bw()

## Analysis 4
# Take in only those who work in head office
headoffice_counts <- employee_attrition_another %>%
  filter(BUSINESS_UNIT == "HEADOFFICE") %>%
  group_by(STATUS_YEAR) %>%
  summarise(count = n())

# Create a new data frame with the years to predict
new_years <- data.frame(STATUS_YEAR = 2016:2020)

# Fit a polynomial regression model to the data
model <- lm(count ~ poly(STATUS_YEAR, 2), data = headoffice_counts)

# Generate predictions for the new years
predictions <- predict(model, newdata = new_years)

# Combine the original data and the predictions into a single data frame
extrapolated_data <- rbind(headoffice_counts, data.frame(STATUS_YEAR = new_years$STATUS_YEAR, count = predictions))

# Plot the extrapolated data with different colors for different x ranges
ggplot(extrapolated_data, aes(x = STATUS_YEAR, y = count, color = ifelse(STATUS_YEAR <= 2015, "red", "blue"))) +
  geom_line() +
  labs(x = "Year", y = "Number of employees in Head Office") +
  scale_x_continuous(breaks = seq(2004, 2020, by = 1), limits = c(2005, 2020)) +
  scale_color_manual(name = "Year Range", values = c("red", "blue"), labels = c("2006-2015", "2016-2020"))

## Analysis 5
# Only take those who are working in stores
store_counts <- employee_attrition_another %>%
  filter(BUSINESS_UNIT == "STORES") %>%
  group_by(STATUS_YEAR) %>%
  summarise(count = n())

# Create a new data frame with the years to predict
new_years <- data.frame(STATUS_YEAR = 2016:2020)

# Fit a polynomial regression model to the data
model <- lm(count ~ poly(STATUS_YEAR, 2), data = store_counts)

# Generate predictions for the new years
predictions <- predict(model, newdata = new_years)

# Combine the original data and the predictions into a single data frame
extrapolated_data <- rbind(store_counts, data.frame(STATUS_YEAR = new_years$STATUS_YEAR, count = predictions))

# Plot the extrapolated data with different colors for different x ranges
ggplot(extrapolated_data, aes(x = STATUS_YEAR, y = count, color = ifelse(STATUS_YEAR <= 2015, "red", "blue"))) +
  geom_line() +
  labs(x = "Year", y = "Number of employees in Store") +
  scale_x_continuous(breaks= seq(2004, 2020, by = 1), limits = c(2005, 2020)) +
  scale_color_manual(name = "Year Range", values = c("red", "blue"), labels = c("2006-2015", "2016-2020"))

## Analysis 6
#To help identify all the job titles
unique(employee_attrition$job_title)

# Subset the data based on job title and status
managerial_positions <- employee_attrition_another %>%
  filter(grepl("CEO.*|Manager.*|Director.*|Officer.*|Admin.*", job_title) & STATUS == "ACTIVE")

# Count the total number of lines that meet the condition per year
managerial_counts <- managerial_positions %>%
  group_by(STATUS_YEAR) %>%
  summarise(count = n())

# Use polynomial regression to extrapolate the number of active managerial positions from 2016 to 2020
fit <- lm(count ~ poly(STATUS_YEAR, 2), data = managerial_counts)
extrapolated_counts <- data.frame(STATUS_YEAR = 2016:2020)
extrapolated_counts$count <- predict(fit, newdata = extrapolated_counts)

# Plot the actual and predicted number of active managerial positions against year
ggplot(managerial_counts, aes(x = STATUS_YEAR, y = count)) +
  geom_line(color = "red", size = 1) +
  geom_line(data = extrapolated_counts, aes(x = STATUS_YEAR, y = count), color = "blue", size = 1) +
  labs(x = "Year", y = "Number of active managerial positions") +
  scale_x_continuous(breaks = seq(2006, 2020, by = 1), limits = c(2006, 2020)) +
  scale_y_continuous(limits = c(-100, max(managerial_counts$count, extrapolated_counts$count) * 1.1)) +
  ggtitle("Actual and Predicted Number of Active Managerial Positions by Year") +
  theme(plot.title = element_text(hjust = 0.5))

## Analysis 7
# Subset the data based on year range and active status
employee_subset <- employee_attrition_another %>%
  filter(grepl("CEO.*|Manager.*|Director.*|Officer.*|Admin.*", job_title) & STATUS != "ACTIVE" & STATUS_YEAR >= 2008 & STATUS_YEAR <= 2010)

# Count the number of employees sharing the same termreason_desc for each year
employee_counts <- employee_subset %>%
  group_by(STATUS_YEAR, termreason_desc) %>%
  summarise(count = n())

# Plot the data
ggplot(employee_counts, aes(x = STATUS_YEAR, y = count, fill = termreason_desc)) +
  geom_bar(stat = "identity", position = "dodge") +
  labs(x = "Year", y = "Number of Employees", fill = "Reason for Termination") +
  ggtitle("Number of Employees by Termination Reason and Year") +
  theme(plot.title = element_text(hjust = 0.5),
        legend.position = "bottom",
        legend.title.align = 0.5) +
  scale_x_continuous(breaks= seq(2007, 2011, by = 1), limits = c(2007, 2011))

# Subset the data based on year range and selected job titles
employee_subset <- employee_attrition_another %>%
  filter(grepl("CEO.*|Manager.*|Director.*|Officer.*|Admin.*", job_title))

# Plot the data
ggplot(employee_subset, aes(x = factor(STATUS_YEAR), y = age, group = STATUS_YEAR)) +
  geom_violin(trim = FALSE, fill = "blue", alpha = 0.5) +
  labs(x = "Year", y = "Age") +
  ggtitle("Age Distribution by Year for Selected Job Titles") +
  theme(plot.title = element_text(hjust = 0.5),
        legend.position = "bottom",
        legend.title.align = 0.5)

### Question 3
## Analysis 1
# Subset the data to only include active employees
employee_active <- subset(employee_attrition, STATUS == "ACTIVE")

# Count the number of employees for each gender
gender_counts <- aggregate(EmployeeID ~ gender_short, data = employee_active, FUN = length)

# Calculate the percentage of employees for each gender
total_employees <- sum(gender_counts$EmployeeID)
gender_counts$Percentage <- (gender_counts$EmployeeID / total_employees) * 100

# Create a bar plot of the percentage of employees by gender
ggplot(gender_counts, aes(x = gender_short, y = Percentage, fill = gender_short)) +
  geom_bar(stat = "identity") +
  geom_text(aes(label = paste0(round(Percentage, 1), "%")), vjust = -0.5) + # add labels for percentage
  xlab("Gender") +
  ylab("Percentage of Employees") +
  ggtitle("Percentage of Employees by Gender") +
  scale_fill_manual(values =c("blue", "blueviolet")) +
  theme_bw()

## Analysis 2
# Filter to active employees only
active_employees <- employee_attrition_another %>%
  filter(STATUS == "ACTIVE")

# Calculate the total count of active employees for each job_title and gender
job_gender_counts <- active_employees %>%
  group_by(job_title, gender_short) %>%
  summarise(count = n())

# Calculate the total count of active employees for each job_title
job_counts <- job_gender_counts %>%
  group_by(job_title) %>%
  summarise(total = sum(count))

# Calculate the percentage of active employees in each job_title that are of the same gender
job_gender_percentages <- job_gender_counts %>%
  left_join(job_counts, by = "job_title") %>%
  mutate(percentage = count / total * 100)

# Filter out bars with 100% percentage
job_gender_percentages <- job_gender_percentages %>%
  filter(percentage < 100)

# Create a bar plot of job_gender_percentages with rotated x-axis label and smaller labels
ggplot(job_gender_percentages, aes(x = job_title, y = percentage, fill = gender_short)) +
  geom_bar(stat = "identity", position = "dodge") +
  geom_text(aes(label = paste0(round(percentage, 1), "%")),
  position = position_dodge(width = 1),
  nudge_x = -0.2,
  vjust = -0.5,
  size = 3,
  hjust = 1) +
  ggtitle("Percentage of Active Employees in Each Job Title by Gender") +
  xlab("") +
  ylab("Percentage of Active Employees") +
  scale_fill_manual(values = c("#0072B2", "#E69F00"), labels = c("Female", "Male")) +
  theme_minimal() +
  theme(axis.text.x = element_text(angle = 45, hjust = 1),
  axis.title.x = element_text(angle = 0, size = 12))

## Analysis 3
# Create the contingency table
gender_dept_table <- table(employee_attrition_another$department_name, employee_attrition_another$gender_short)

# Check the table
gender_dept_table

# Perform the chi-square test
chisq.test(gender_dept_table)

## Analysis 4
# Filter to active employees only
active_employees <- employee_attrition_another %>%
  filter(STATUS == "ACTIVE")

# Calculate the total count of active employees for each job_title and gender
job_gender_counts <- active_employees %>%
  group_by(job_title, gender_short) %>%
  summarise(count = n())

# Calculate the total count of active employees for each job_title
job_counts <- job_gender_counts %>%
  group_by(job_title) %>%
  summarise(total = sum(count))

# Calculate the percentage of active employees in each job_title that are of the same gender
job_gender_percentages <- job_gender_counts %>%
  left_join(job_counts, by = "job_title") %>%
  mutate(percentage = count / total * 100)

# Filter out bars with 100% percentage
job_gender_percentages <- job_gender_percentages %>%
  filter(percentage < 100)

# Create a bar plot of job_gender_percentages with rotated x-axis label and smaller labels
ggplot(job_gender_percentages, aes(x = job_title, y = percentage, fill = gender_short)) +
  geom_bar(stat = "identity", position = "dodge") +
  geom_text(aes(label = paste0(round(percentage, 1), "%")),
  position = position_identity(),
  vjust = -0.5,
  size = 3,
  hjust = 1) +
  ggtitle("Percentage of Active Employees in Each Job Title by Gender") +
  xlab("Job Position") +
  ylab("Percentage of Active Employees") +
  scale_fill_manual(values = c("#0072B2", "#E69F00"), labels = c("Female", "Male")) +
  theme_minimal() +
  theme(axis.text.x = element_text(angle = 45, hjust = 1),
  axis.title.x = element_text(angle = 0, size = 12))

## Analysis 5
# Create the contingency table
gender_job_table <- table(employee_attrition_another$job_title, employee_attrition_another$gender_short)

# Check the table
gender_job_table

# Perform Fisher's exact test with simulated p-value
fisher.test(gender_job_table, simulate.p.value = TRUE)

## Analysis 6
# Create a histogram of age distribution with adjusted breaks
ggplot(employee_attrition, aes(x = age, y = after_stat(density), fill = after_stat(density), color = "black")) +
  geom_histogram(binwidth = 5, alpha = 0.8, position = "identity") +
  scale_fill_gradient(low = "lightblue", high = "darkblue") +
  scale_color_manual(values = "black") +
  labs(x = "Age", y = "Density", title = "Current Age Distribution of Employees") +
  theme_classic()

### Question 4
## Analysis 1
# Filter the dataset to include only laid off employees
laid_off <- employee_attrition[employee_attrition$termreason_desc == "Layoff", ]

# Count the number of occurrences of each age
age_counts <- table(laid_off$age)

# Convert the counts to percentages
age_percents <- prop.table(age_counts) * 100

# Create a data frame from the age percentages
age_df <- data.frame(age = names(age_percents), percent = age_percents)

# Set column headings using colnames()
colnames(age_df) <- c("Column 1", "age", "percent")

# Create the bar plot
ggplot(age_df, aes(x = age, y = percent)) + 
  geom_bar(stat = "identity", fill = "steelblue") + 
  xlab("Age") + ylab("Percentage of Laid Off Employees") + 
  ggtitle("Percentage Distribution of Laid Off Employees by Age")

## Analysis 2
#Filter the dataset to include only laid off employees:
laid_off <- employee_attrition[employee_attrition$termreason_desc == "Layoff", ]

#Count the number of occurrences of each length of service:
los_counts <- table(laid_off$length_of_service)

#Convert the counts to percentages:
los_percents <- prop.table(los_counts) * 100

#Create a data frame from the length of service percentages:
los_df <- data.frame(length_of_service = names(los_percents), percent = los_percents)

#Set column headings using colnames():
colnames(los_df) <- c("Column 1", "length_of_service", "percent")

#Create the bar plot:
ggplot(los_df, aes(x = length_of_service, y = percent)) +
  geom_bar(stat = "identity", fill = "steelblue") +
  xlab("Length of Service") + ylab("Percentage of Laid Off Employees") +
  ggtitle("Percentage Distribution of Laid Off Employees by Length of Service")

## Analysis 3
#Filter the dataset to include only laid off employees:
laid_off <- employee_attrition[employee_attrition$termreason_desc == "Layoff", ]

#Count the number of occurrences of each gender:
gender_counts <- table(laid_off$gender_short)

#Convert the counts to percentages:
gender_percents <- prop.table(gender_counts) * 100

#Create a data frame from the gender percentages:
gender_df <- data.frame(gender = names(gender_percents), percent = gender_percents)

#Set column headings using colnames():
colnames(gender_df) <- c("Column 1", "gender", "percent")

#Create the bar plot:
ggplot(gender_df, aes(x = gender, y = percent)) +
  geom_bar(stat = "identity", fill = "steelblue") +
  xlab("Gender") + ylab("Percentage of Laid Off Employees") +
  ggtitle("Percentage Distribution of Laid Off Employees by Gender") +
  geom_text(aes(label = sprintf("%.1f%%", percent), y = percent), vjust = -0.5)

## Analysis 4
# Filter the dataset to include only laid off employees
laid_off <- employee_attrition[employee_attrition$termreason_desc == "Layoff", ]

# Count the number of occurrences of each city name
city_counts <- table(laid_off$city_name)

# Convert the counts to percentages
city_percents <- prop.table(city_counts) * 100

# Create a data frame from the city percentages
city_df <- data.frame(city_name = names(city_percents), percent = city_percents)

# Set column headings using colnames()
colnames(city_df) <- c("Column 1", "city_name", "percent")

# Create the bar plot
ggplot(city_df, aes(x = city_name, y = percent)) +
  geom_bar(stat = "identity", fill = "steelblue") +
  xlab("City") + ylab("Percentage of Laid Off Employees") +
  ggtitle("Percentage Distribution of Laid Off Employees by City") +
  geom_text(aes(label = sprintf("%.1f%%", percent), y = percent), vjust = -0.5) +
  theme(axis.text.x = element_text(angle = 45, hjust = 1))

## Analysis 5
# Filter the dataset to include only laid off employees
laid_off <- employee_attrition[employee_attrition$termreason_desc == "Layoff", ]

# Calculate the birth year
laid_off$birth_year <- as.numeric(format(as.Date(paste0(laid_off$STATUS_YEAR, "-01-01")), "%Y")) - laid_off$age

# Count the number of occurrences of each birth year
year_counts <- table(laid_off$birth_year)

# Convert the counts to percentages
year_percents <- prop.table(year_counts) * 100

# Create a data frame from the birth year percentages
year_df <- data.frame(birth_year = names(year_percents), percent = year_percents)

# Set column headings using colnames()
colnames(year_df) <- c("Column 1", "birth_year", "percent")

# Create the bar plot
ggplot(year_df, aes(x = birth_year, y = percent)) +
  geom_bar(stat = "identity", fill = "steelblue") +
  xlab("Birth Year") + ylab("Percentage of Laid Off Employees") +
  ggtitle("Percentage Distribution of Laid Off Employees by Birth Year") +
  geom_text(aes(label = sprintf("%.1f%%", percent), y = percent), vjust = -0.5) +
  theme(axis.text.x = element_text(angle = 45, hjust = 1))

### Question 5
## Analysis 1
# Generate a summary of the age column
summary(employee_attrition$age)

# Generate a summary of the length_of_service column
summary(employee_attrition$length_of_service)

## Analysis 2
# Subset the data to only include rows where gender_short is "F"
female_data <- employee_attrition[employee_attrition$gender_short == "F",]

# Generate a summary of the age column for female employees
summary(female_data$age)

# Generate a summary of the length_of_service column for female employees
summary(female_data$length_of_service)

# Subset the data to only include rows where gender_short is "F"
male_data <- employee_attrition[employee_attrition$gender_short == "M",]

# Generate a summary of the age column for male employees
summary(male_data$age)

# Generate a summary of the length_of_service column for male employees
summary(male_data$length_of_service)

## Analysis 3
# Calculate the mean age and length_of_service for each department_name
mean_age_service <- aggregate(cbind(age, length_of_service) ~ department_name, employee_attrition, mean)

# Reorder the department_name by mean age value
mean_age_service$department_name <- reorder(mean_age_service$department_name, mean_age_service$age)

# Create a bar chart of mean age by department_name
library(ggplot2)
ggplot(mean_age_service, aes(x=department_name, y=age)) +
  geom_bar(stat="identity", fill="#69b3a2") +
  geom_text(aes(label=round(age,1)), vjust=-0.5, color="black", size=3.5) +
  ggtitle("Mean Age by Department") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1)) +
  coord_flip()

# Reorder the department_name by mean length_of_service value
mean_age_service$department_name <- reorder(mean_age_service$department_name, mean_age_service$length_of_service)

# Create a bar chart of mean length_of_service by department_name
ggplot(mean_age_service, aes(x=department_name, y=length_of_service)) +
  geom_bar(stat="identity", fill="#69b3a2") +
  geom_text(aes(label=round(length_of_service,1)), vjust=-0.5, color="black", size=3.5) +
  ggtitle("Mean Length of Service by Department") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1)) +
  coord_flip()


## Analysis 4
# Calculate the mean age and length_of_service for each job_title
mean_age_service <- aggregate(cbind(age, length_of_service) ~ job_title, employee_attrition, mean)

# Reorder the job_title by mean age value
mean_age_service$job_title <- reorder(mean_age_service$job_title, mean_age_service$age)

# Create a bar chart of mean age by job_title
ggplot(mean_age_service, aes(x=job_title, y=age)) +
  geom_bar(stat="identity", fill="#69b3a2") +
  geom_text(aes(label=round(age,1)), vjust=-0.5, color="black", size=3.5) +
  ggtitle("Mean Age by Job Title") +
  theme(axis.text.x = element_text(angle = 45, hjust =1)) +
  coord_flip()

# Reorder the job_title by mean length_of_service value
mean_age_service$job_title <- reorder(mean_age_service$job_title, mean_age_service$length_of_service)

# Create a bar chart of mean length_of_service by job_title
ggplot(mean_age_service, aes(x=job_title, y=length_of_service)) +
  geom_bar(stat="identity", fill="#69b3a2") +
  geom_text(aes(label=round(length_of_service,1)), vjust=-0.5, color="black", size=3.5) +
  ggtitle("Mean Length of Service by Job Title") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1)) +
  coord_flip()

## Analysis 5
# Calculate the mean age and length_of_service for each city_name
mean_age_service <- aggregate(cbind(age, length_of_service) ~ city_name, employee_attrition, mean)

# Reorder the city_name by mean age value
mean_age_service$city_name <- reorder(mean_age_service$city_name, mean_age_service$age)

# Create a bar chart of mean age by city_name
library(ggplot2)
ggplot(mean_age_service, aes(x=city_name, y=age)) +
  geom_bar(stat="identity", fill="#69b3a2") +
  geom_text(aes(label=round(age,1)), vjust=0.5, color="black", size=3.5) +
  ggtitle("Mean Age by City") +
  theme(axis.text.x = element_text(angle = 45, hjust =1)) +
  coord_flip()

# Reorder the city_name by mean length_of_service value
mean_age_service$city_name <- reorder(mean_age_service$city_name, mean_age_service$length_of_service)

# Create a bar chart of mean length_of_service by city_name
ggplot(mean_age_service, aes(x=city_name, y=length_of_service)) +
  geom_bar(stat="identity", fill="#69b3a2") +
  geom_text(aes(label=round(length_of_service,1)), vjust=0.5, color="black", size=3.5) +
  ggtitle("Mean Length of Service by City") +
  theme(axis.text.x = element_text(angle = 45, hjust = 1)) +
  coord_flip()
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Class representing a task
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public int CategoryId { get; set; }
}

// Class representing a category
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ConsoleColor Color { get; set; }
}

// Class for managing tasks
public class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(int taskId)
    {
        tasks.RemoveAll(t => t.Id == taskId);
    }

    taskManager.AddTask(new Task { Id = 1, Title = "Task 1", Description = "Description for Task 1", DueDate = DateTime.Now.AddDays(1), Priority = 1, CategoryId = 1 });
    taskManager.AddTask(new Task { Id = 2, Title = "Task 2", Description = "Description for Task 2", DueDate = DateTime.Now.AddDays(2), Priority = 2, CategoryId = 2 });

     taskManager.DisplayTasks();

        // Removing a task
        taskManager.RemoveTask(1);

        Console.WriteLine("After removing Task 1:");
        taskManager.DisplayTasks();
}

// Class for managing categories
public class CategoryManager
{
    private List<Category> categories;

    public CategoryManager()
    {
        categories = new List<Category>();
    }

    public void AddCategory(Category category)
    {
        categories.Add(category);
    }

    public void RemoveCategory(int categoryId)
    {
        Category categoryToRemove = categories.Find(c => c.Id == categoryId);
        if (categoryToRemove != null)
        {
            categories.Remove(categoryToRemove);
        }
    }

    public Category GetCategoryById(int categoryId)
    {
        return categories.FirstOrDefault(c => c.Id == categoryId);
    }

    public List<Category> GetAllCategories()
    {
        return categories;
    }

    public List<Task> GetTasksByCategory(int categoryId)
    {
        // Assuming there's a TaskManager class to manage tasks
        TaskManager taskManager = new TaskManager();
        return taskManager.GetTasks().FindAll(t => t.CategoryId == categoryId);
    }

    public Dictionary<Category, int> GetCategoriesWithTaskCount()
    {
        Dictionary<Category, int> categoryTaskCount = new Dictionary<Category, int>();

        // Assuming there's a TaskManager class to manage tasks
        TaskManager taskManager = new TaskManager();
        List<Task> tasks = taskManager.GetTasks();

        foreach (var category in categories)
        {
            int taskCount = tasks.Count(t => t.CategoryId == category.Id);
            categoryTaskCount.Add(category, taskCount);
        }

        return categoryTaskCount;
    }

    public bool IsValidCategory(Category category)
    {
        // Check if the category name is unique
        return categories.All(c => c.Name != category.Name);
    }
}

public class UIManager
{
    // Implement user interface methods
}

// Class for handling file operations
public class FileManager
{
    private string filePath = "tasks.txt";

    public void SaveTasks(List<Task> tasks)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Task task in tasks)
            {
                writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.DueDate},{task.Priority},{task.CategoryId}");
            }
        }
    }

    public List<Task> LoadTasks()
    {
        List<Task> tasks = new List<Task>();
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Task task = new Task
                    {
                        Id = int.Parse(parts[0]),
                        Title = parts[1],
                        Description = parts[2],
                        DueDate = DateTime.Parse(parts[3]),
                        Priority = int.Parse(parts[4]),
                        CategoryId = int.Parse(parts[5])
                    };
                    tasks.Add(task);
                }
            }
        }
        return tasks;
    }
}

// Example of a Windows Forms task form

public class TaskForm : Form
{
    private Label titleLabel;
    private TextBox titleTextBox;
    private Label descriptionLabel;
    private TextBox descriptionTextBox;
    private Label dueDateLabel;
    private DateTimePicker dueDateTimePicker;
    private Label priorityLabel;
    private NumericUpDown priorityNumericUpDown;
    private Button addButton;

    public TaskForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Add Task";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;

        titleLabel = new Label();
        titleLabel.Text = "Doing of Assignment ";
        titleLabel.Location = new System.Drawing.Point(20, 20);

        titleTextBox = new TextBox();
        titleTextBox.Location = new System.Drawing.Point(100, 20);
        titleTextBox.Size = new System.Drawing.Size(200, 20);

        descriptionLabel = new Label();
        descriptionLabel.Text = "Title:";
        descriptionLabel.Location = new System.Drawing.Point(20, 50);

        descriptionTextBox = new TextBox();
        descriptionTextBox.Multiline = true;
        descriptionTextBox.Size = new System.Drawing.Size(280, 80);
        descriptionTextBox.Location = new System.Drawing.Point(100, 50);

        dueDateLabel = new Label();
        dueDateLabel.Text = "Description:";
        dueDateLabel.Location = new System.Drawing.Point(20, 140);

        dueDateTimePicker = new DateTimePicker();
        dueDateTimePicker.Location = new System.Drawing.Point(100, 140);

        priorityLabel = new Label();
        priorityLabel.Text = "Priority:";
        priorityLabel.Location = new System.Drawing.Point(20, 180);

        priorityNumericUpDown = new NumericUpDown();
        priorityNumericUpDown.Minimum = 1;
        priorityNumericUpDown.Maximum = 10;
        priorityNumericUpDown.Value = 5;
        priorityNumericUpDown.Location = new System.Drawing.Point(100, 180);

        addButton = new Button();
        addButton.Text = "Add Task";
        addButton.Location = new System.Drawing.Point(120, 220);
        addButton.Size = new System.Drawing.Size(100, 30);
        addButton.Click += AddButton_Click;

        this.Controls.Add(titleLabel);
        this.Controls.Add(titleTextBox);
        this.Controls.Add(descriptionLabel);
        this.Controls.Add(descriptionTextBox);
        this.Controls.Add(dueDateLabel);
        this.Controls.Add(dueDateTimePicker);
        this.Controls.Add(priorityLabel);
        this.Controls.Add(priorityNumericUpDown);
        this.Controls.Add(addButton);
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        
    }
}

// Example of a Windows Forms category form
public class CategoryForm
{
        public CategoryForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Add Category";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;

        nameLabel = new Label();
        nameLabel.Text = "Name:";
        nameLabel.Location = new System.Drawing.Point(20, 20);

        nameTextBox = new TextBox();
        nameTextBox.Location = new System.Drawing.Point(100, 20);
        nameTextBox.Size = new System.Drawing.Size(200, 20);

        addButton = new Button();
        addButton.Text = "Add Category";
        addButton.Location = new System.Drawing.Point(120, 60);
        addButton.Size = new System.Drawing.Size(100, 30);
        addButton.Click += AddButton_Click;

        this.Controls.Add(nameLabel);
        this.Controls.Add(nameTextBox);
        this.Controls.Add(addButton);
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        // Handle adding the category here
        // You would typically retrieve the category name from the textbox
        // and use it to create a new Category object and add it to the CategoryManager
    }
}

class Program
{
    static void Main(string[] args)
    {
        Application.Run(new TaskForm()); // Show TaskForm
        // Application.Run(new CategoryForm()); // Show CategoryForm
    }
}


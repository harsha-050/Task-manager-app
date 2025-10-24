import { useState, useEffect } from 'react'
import './App.css'
import { TaskItem, getTasks, createTask, updateTask, deleteTask } from './api/taskApi'

function App() {
  const [tasks, setTasks] = useState<TaskItem[]>([])
  const [input, setInput] = useState('')
  const [editing, setEditing] = useState<TaskItem | null>(null)
  const [editInput, setEditInput] = useState('')
  const [isLoading, setIsLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    fetchTasks()
  }, [])

  const fetchTasks = async () => {
    try {
      setIsLoading(true)
      setError(null)
      const data = await getTasks()
      setTasks(data)
    } catch (err) {
      setError('Failed to load tasks. Make sure the backend API is running.')
      console.error(err)
    } finally {
      setIsLoading(false)
    }
  }

  const addTask = async () => {
    if (!input.trim()) {
      alert('Please enter a task description')
      return
    }

    try {
      setError(null)
      const task = await createTask(input)
      setTasks([...tasks, task])
      setInput('')
    } catch (err) {
      setError('Failed to create task')
      console.error(err)
    }
  }

  const toggleComplete = async (task: TaskItem) => {
    try {
      setError(null)
      await updateTask(task.id, task.description, !task.isCompleted)
      setTasks(tasks.map(t => 
        t.id === task.id ? { ...t, isCompleted: !t.isCompleted } : t
      ))
    } catch (err) {
      setError('Failed to update task')
      console.error(err)
    }
  }

  const startEdit = (task: TaskItem) => {
    setEditing(task)
    setEditInput(task.description)
  }

  const saveEdit = async () => {
    if (!editing || !editInput.trim()) {
      alert('Please enter a task description')
      return
    }

    try {
      setError(null)
      await updateTask(editing.id, editInput, editing.isCompleted)
      setTasks(tasks.map(t => 
        t.id === editing.id ? { ...t, description: editInput } : t
      ))
      setEditing(null)
      setEditInput('')
    } catch (err) {
      setError('Failed to update task')
      console.error(err)
    }
  }

  const cancelEdit = () => {
    setEditing(null)
    setEditInput('')
  }

  const removeTask = async (id: number) => {
    if (!confirm('Are you sure you want to delete this task?')) {
      return
    }

    try {
      setError(null)
      await deleteTask(id)
      setTasks(tasks.filter(t => t.id !== id))
    } catch (err) {
      setError('Failed to delete task')
      console.error(err)
    }
  }

  return (
    <div className="App">
      <h1>🎯 Task Manager</h1>
      
      {error && <div className="error">{error}</div>}
      
      <div className="add-task-section">
        <input
          type="text"
          placeholder="Plan a new task..."
          value={input}
          onChange={(e) => setInput(e.target.value)}
          onKeyPress={(e) => e.key === 'Enter' && addTask()}
        />
        <button onClick={addTask}>Add Task</button>
      </div>

      {isLoading ? (
        <p>Loading tasks...</p>
      ) : (
        <div className="task-list">
          {tasks.length === 0 ? (
            <p className="no-tasks">No tasks yet. Add one above!</p>
          ) : (
            tasks.map(task => (
              <div key={task.id} className={`task-item ${task.isCompleted ? 'completed' : ''}`}>
                {editing?.id === task.id ? (
                  <div className="edit-mode">
                    <input
                      type="text"
                      value={editInput}
                      onChange={(e) => setEditInput(e.target.value)}
                      onKeyPress={(e) => e.key === 'Enter' && saveEdit()}
                    />
                    <div className="edit-buttons">
                      <button onClick={saveEdit} className="save-btn">Save</button>
                      <button onClick={cancelEdit} className="cancel-btn">Cancel</button>
                    </div>
                  </div>
                ) : (
                  <>
                    <div className="task-content">
                      <input
                        type="checkbox"
                        checked={task.isCompleted}
                        onChange={() => toggleComplete(task)}
                      />
                      <span className="task-description">{task.description}</span>
                    </div>
                    <div className="task-actions">
                      <button onClick={() => startEdit(task)} className="edit-btn">Edit</button>
                      <button onClick={() => removeTask(task.id)} className="delete-btn">Delete</button>
                    </div>
                  </>
                )}
              </div>
            ))
          )}
        </div>
      )}
    </div>
  )
}

export default App

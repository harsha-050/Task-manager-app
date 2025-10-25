import axios from 'axios'

const BASE_URL = 'https://task-manager-api-v8fn.onrender.com/api'

export interface TaskItem {
  id: number
  description: string
  isCompleted: boolean
}

const client = axios.create({
  baseURL: BASE_URL,
  headers: {
    'Content-Type': 'application/json'
  }
})

export const getTasks = async (): Promise<TaskItem[]> => {
  const res = await client.get<TaskItem[]>('/tasks')
  return res.data
}

export const createTask = async (description: string): Promise<TaskItem> => {
  const res = await client.post<TaskItem>('/tasks', { description })
  return res.data
}

export const updateTask = async (
  id: number,
  description: string,
  isCompleted: boolean
): Promise<void> => {
  await client.put(`/tasks/${id}`, { description, isCompleted })
}

export const deleteTask = async (id: number): Promise<void> => {
  await client.delete(`/tasks/${id}`)
}

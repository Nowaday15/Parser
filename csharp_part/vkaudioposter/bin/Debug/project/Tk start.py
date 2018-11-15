from tkinter import *

root = Tk()
root.geometry('1280x720')


scrollbar = Scrollbar(root, orient=VERTICAL)
listbox = Listbox(root, yscrollcommand=scrollbar.set)
scrollbar.config(command=listbox.yview)
scrollbar.pack(side=RIGHT, fill=Y)
listbox.pack()

root.mainloop()
import sqlite3
import csv

conn = sqlite3.connect("RateMyClasses/RateMyClasses.db")
cur = conn.cursor()

#delete all table data
cur.execute("DELETE FROM COURSE;")
conn.commit()

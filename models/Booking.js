const mongoose = require('mongoose');

const bookingSchema = new mongoose.Schema({
  workspaceId: {
    type: mongoose.Schema.Types.ObjectId,
    ref: 'Workspace',
    required: true
  },
  userId: {
    type: String,
    required: true
  },
  date: {
    type: Date,
    required: true,
    validate: {
      validator: function(value) {
        return value >= new Date().setHours(0, 0, 0, 0);
      },
      message: 'Booking date cannot be in the past'
    }
  },
  startTime: {
    type: String,
    required: true,
    match: /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/,
    validate: {
      validator: function(value) {
        const timeRegex = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/;
        if (!timeRegex.test(value)) return false;
        
        const [hours, minutes] = value.split(':').map(Number);
        return hours >= 8 && hours <= 20;
      },
      message: 'Start time must be between 08:00 and 20:00'
    }
  },
  endTime: {
    type: String,
    required: true,
    match: /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/,
    validate: [
      {
        validator: function(value) {
          return value > this.startTime;
        },
        message: 'End time must be after start time'
      },
      {
        validator: function(value) {
          const [endHours, endMinutes] = value.split(':').map(Number);
          const [startHours] = this.startTime.split(':').map(Number);
          return endHours - startHours <= 8;
        },
        message: 'Booking duration cannot exceed 8 hours'
      }
    ]
  },
  status: {
    type: String,
    enum: ['pending', 'confirmed', 'cancelled'],
    default: 'pending'
  }
}, { timestamps: true });

module.exports = mongoose.model('Booking', bookingSchema);
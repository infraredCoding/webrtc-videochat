<template>
  <div class="min-w-screen h-screen bg-amber-50">
    <h1 class="text-center text-4xl pt-10">Video Call Room</h1>
    <div class="flex gap-5 justify-center mt-6">
      <video
        ref="localVideo"
        autoplay
        playsinline
        muted
        style="width: 300px"
        class="rounded-md shadow-lg shadow-rose-100 bg-slate-900"
      ></video>
      <video
        ref="remoteVideo"
        autoplay
        playsinline
        style="width: 300px"
        class="rounded-md shadow-lg shadow-rose-100 bg-slate-900"
      ></video>
    </div>

    <!-- controls -->
    <div class="flex gap-5 justify-center mt-6">
      <button
        class="px-4 py-3 rounded-lg bg-rose-700 text-zinc-100 cursor-pointer"
        @click.prevent="toggleMic"
      >
        <svg
          v-if="isMicOn"
          xmlns="http://www.w3.org/2000/svg"
          height="24"
          width="24"
          viewBox="0 0 24 24"
          fill="#fff"
        >
          <path
            d="M11.9998 1C14.7612 1 16.9998 3.23858 16.9998 6V10C16.9998 12.7614 14.7612 15 11.9998 15C9.23833 15 6.99976 12.7614 6.99976 10V6C6.99976 3.23858 9.23833 1 11.9998 1ZM3.05469 11H5.07065C5.55588 14.3923 8.47329 17 11.9998 17C15.5262 17 18.4436 14.3923 18.9289 11H20.9448C20.4837 15.1716 17.1714 18.4839 12.9998 18.9451V23H10.9998V18.9451C6.82814 18.4839 3.51584 15.1716 3.05469 11Z"
          ></path>
        </svg>

        <svg
          v-else
          xmlns="http://www.w3.org/2000/svg"
          height="24"
          width="24"
          viewBox="0 0 24 24"
          fill="currentColor"
        >
          <path
            d="M16.4249 17.839C15.3929 18.4228 14.2341 18.8087 13.0002 18.9451V23H11.0002V18.9451C6.82854 18.4839 3.51623 15.1716 3.05509 11H5.07105C5.55627 14.3923 8.47368 17 12.0002 17C13.0503 17 14.0464 16.7688 14.9404 16.3544L13.3902 14.8042C12.9489 14.9317 12.4825 15 12.0002 15C9.23873 15 7.00016 12.7614 7.00016 10V8.41421L1.39355 2.80761L2.80777 1.3934L22.6068 21.1924L21.1925 22.6066L16.4249 17.839ZM19.3747 15.1604L17.9323 13.7179C18.4407 12.9084 18.788 11.9874 18.9293 11H20.9452C20.7754 12.5366 20.2187 13.9565 19.3747 15.1604ZM16.4658 12.2514L7.68575 3.47139C8.55427 1.99268 10.1613 1 12.0002 1C14.7616 1 17.0002 3.23858 17.0002 6V10C17.0002 10.8099 16.8076 11.5748 16.4658 12.2514Z"
          ></path>
        </svg>
      </button>

      <button
        class="px-4 py-3 rounded-lg bg-rose-700 text-zinc-100 cursor-pointer"
        @click.prevent="toggleVideo"
      >
        <svg
          v-if="isVideoOn"
          xmlns="http://www.w3.org/2000/svg"
          height="24"
          width="24"
          viewBox="0 0 24 24"
          fill="currentColor"
        >
          <path
            d="M17 9.2L22.2133 5.55071C22.4395 5.39235 22.7513 5.44737 22.9096 5.6736C22.9684 5.75764 23 5.85774 23 5.96033V18.0397C23 18.3158 22.7761 18.5397 22.5 18.5397C22.3974 18.5397 22.2973 18.5081 22.2133 18.4493L17 14.8V19C17 19.5523 16.5523 20 16 20H2C1.44772 20 1 19.5523 1 19V5C1 4.44772 1.44772 4 2 4H16C16.5523 4 17 4.44772 17 5V9.2Z"
          ></path>
        </svg>

        <svg
          v-else
          xmlns="http://www.w3.org/2000/svg"
          height="24"
          width="24"
          viewBox="0 0 24 24"
          fill="currentColor"
        >
          <path
            d="M17 18.4142L21.1925 22.6067L22.6067 21.1925L2.80769 1.39349L1.39348 2.80771L2.58579 4.00001H2C1.44772 4.00001 1 4.44773 1 5.00001V19C1 19.5523 1.44772 20 2 20H16C16.5523 20 17 19.5523 17 19V18.4142ZM16 4.00001H8.21402L22.7083 18.4943C22.8805 18.4153 23 18.2415 23 18.0397V5.96034C23 5.85776 22.9684 5.75765 22.9096 5.67361C22.7513 5.44739 22.4395 5.39237 22.2133 5.55073L17 9.20001V5.00001C17 4.44773 16.5523 4.00001 16 4.00001Z"
          ></path>
        </svg>
      </button>
    </div>

    <div class="flex gap-5 justify-center mt-6">
      <button
        class="px-4 py-3 rounded-lg bg-rose-700 text-zinc-100 cursor-pointer"
        @click.prevent="createOffer"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          height="24"
          width="24"
          viewBox="0 0 24 24"
          fill="currentColor"
        >
          <path
            d="M21 16.42V19.9561C21 20.4811 20.5941 20.9167 20.0705 20.9537C19.6331 20.9846 19.2763 21 19 21C10.1634 21 3 13.8366 3 5C3 4.72371 3.01545 4.36687 3.04635 3.9295C3.08337 3.40588 3.51894 3 4.04386 3H7.5801C7.83678 3 8.05176 3.19442 8.07753 3.4498C8.10067 3.67907 8.12218 3.86314 8.14207 4.00202C8.34435 5.41472 8.75753 6.75936 9.3487 8.00303C9.44359 8.20265 9.38171 8.44159 9.20185 8.57006L7.04355 10.1118C8.35752 13.1811 10.8189 15.6425 13.8882 16.9565L15.4271 14.8019C15.5572 14.6199 15.799 14.5573 16.001 14.6532C17.2446 15.2439 18.5891 15.6566 20.0016 15.8584C20.1396 15.8782 20.3225 15.8995 20.5502 15.9225C20.8056 15.9483 21 16.1633 21 16.42Z"
          ></path>
        </svg>
      </button>
    </div>
  </div>
</template>

<script>
import * as signalR from '@microsoft/signalr'
// const { v4: uuidv4 } = require('uuid');
import { v4 as uuidv4 } from 'uuid'

export default {
  data() {
    return {
      connection: null,
      peerConnection: null,
      roomId: 'test-room',
      iceServers: [{ urls: 'stun:stun.l.google.com:19302' }],
      localStream: null,
      remoteStream: null,
      signalingServerUrl: 'http://localhost:5019/video',

      // controls
      isMicOn: true,
      isVideoOn: true,
    }
  },
  async mounted() {
    console.log(this.roomId)
    await this.initializeConnection()
    await this.startLocalStream()
  },
  methods: {
    // cosmetics
    toggleMic() {
      this.isMicOn = !this.isMicOn
      this.localStream.getAudioTracks().forEach((track) => {
        track.enabled = this.isMicOn
      })
    },
    toggleVideo() {
      this.isVideoOn = !this.isVideoOn
      this.localStream.getVideoTracks().forEach((track) => {
        track.enabled = this.isVideoOn
      })
    },

    // main stuff
    async initializeConnection() {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(this.signalingServerUrl)
        .withAutomaticReconnect()
        .build()

      // SignalR event handlers
      this.connection.on('ReceiveOffer', async (offer) => {
        await this.handleOffer(offer)
      })

      this.connection.on('ReceiveAnswer', async (answer) => {
        await this.handleAnswer(answer)
      })

      this.connection.on('ReceiveIceCandidate', async (candidate) => {
        await this.handleIceCandidate(candidate)
      })

      // Start the connection
      try {
        await this.connection.start()
        console.log('Connected to SignalR server')
      } catch (err) {
        console.error('Error connecting to SignalR server:', err)
      }
    },
    async startLocalStream() {
      this.localStream = await navigator.mediaDevices.getUserMedia({
        video: true,
        audio: true,
      })
      this.$refs.localVideo.srcObject = this.localStream
    },
    async createPeerConnection() {
      this.peerConnection = new RTCPeerConnection({ iceServers: this.iceServers })

      // Add local stream to the peer connection
      this.localStream.getTracks().forEach((track) => {
        this.peerConnection.addTrack(track, this.localStream)
      })

      // Handle remote stream
      this.peerConnection.ontrack = (event) => {
        if (!this.remoteStream) {
          this.remoteStream = new MediaStream()
          this.$refs.remoteVideo.srcObject = this.remoteStream
        }
        this.remoteStream.addTrack(event.track)
      }

      // Handle ICE candidates
      this.peerConnection.onicecandidate = (event) => {
        if (event.candidate) {
          this.connection.invoke('SendIceCandidate', this.roomId, JSON.stringify(event.candidate))
        }
      }
    },
    async createOffer() {
      await this.createPeerConnection()

      const offer = await this.peerConnection.createOffer()
      await this.peerConnection.setLocalDescription(offer)

      // console.log(offer.toJSON())

      this.connection.invoke('SendOffer', this.roomId, JSON.stringify(offer))
    },
    async handleOffer(offer) {
      await this.createPeerConnection()
      await this.peerConnection.setRemoteDescription(new RTCSessionDescription(JSON.parse(offer)))

      const answer = await this.peerConnection.createAnswer()
      await this.peerConnection.setLocalDescription(answer)

      // Send the answer to the signaling server
      this.connection.invoke('SendAnswer', this.roomId, JSON.stringify(answer))
    },
    async handleAnswer(answer) {
      await this.peerConnection.setRemoteDescription(new RTCSessionDescription(JSON.parse(answer)))
    },
    async handleIceCandidate(candidate) {
      await this.peerConnection.addIceCandidate(JSON.parse(candidate))
    },
  },
}
</script>

<style>
video {
  display: block;
}
</style>
